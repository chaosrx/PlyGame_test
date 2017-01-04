// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyBloxKit;
using plyGame;

namespace DiaQ
{
	[plyBlock("Dialogue and Quest", "DiaQ", "Begin Graph", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Begin walking a DiaQ Graph (Dialogue flow).")]
	public class DiaQ_BeginGraph_plyBlock : plyBlock
	{

		[plyBlockField("Begin DiaQ Graph:", ShowIfTargetFieldInvalid = "graphId", ShowName = true, ShowValue = true, Description = "You can either select the Graph from a list or choose to identify it by its name or custom ident. Choose 'none' from the list to use the name/ ident method and then add a String block in the provided space so that you can enter the name/ ident.")]
		public String_Value graphString;

		[plyBlockField("Begin DiaQ Graph", CustomValueStyle = "plyBlox_BoldLabel")]
		public plyGraphFieldData graphId = new plyGraphFieldData();

		[plyBlockField("Ident type", ShowIfTargetFieldInvalid = "graphId", Description = "What kind of value did you enter to identify the Graph by? Only when you did not select the graph from a list.")]
		public DiaQIdentType identType = DiaQIdentType.Name;

		[plyBlockField("Cache target", Description = "Tell plyBlox if it can cache a reference to the Target Graph, if you know it will not change, improving performance a little.")]
		public bool cacheTarget = true;

		private UniqueID id = null;
		private plyGraph graph = null;

		public override void Created()
		{
			blockIsValid = true;
		}

		public override void Initialise()
		{
			if (string.IsNullOrEmpty(graphId.id))
			{
				if (graphString == null)
				{
					Log(LogType.Error, "Graph name/ ident is not set.");
					return;
				}
			}
			else
			{
				graphString = null;
			}
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (graph == null)
			{
				if (graphString != null)
				{
					string s = graphString.RunAndGetString();
					if (string.IsNullOrEmpty(s))
					{
						Log(LogType.Error, "Graph name/ ident is not set.");
						return BlockReturn.Error;
					}

					if (identType == DiaQIdentType.CutomIdent) graph = DiaQEngine.Instance.graphManager.GetGraphByIdent(s);
					else graph = DiaQEngine.Instance.graphManager.GetGraphByName(s);

					if (graph == null)
					{
						Log(LogType.Error, string.Format("Graph with {0} = {1} could not be found.", identType, s));
						return BlockReturn.Error;
					}
				}
				else
				{
					if (id == null) id = new UniqueID(graphId.id);
					graph = DiaQEngine.Instance.graphManager.GetGraph(id);
					if (graph == null)
					{
						Log(LogType.Error, "Could not find the specified Graph. You might have removed it without updating the Block.");
						return BlockReturn.Error;
					}
				}
			}

			DiaQEngine.Instance.graphManager.BeginGraph(graph);

			if (!cacheTarget) graph = null;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}