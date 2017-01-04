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
using DiaQ;

namespace DiaQ
{
	[plyBlock("Dialogue and Quest", "DiaQ", "Dialogue Response Text", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "DiaQ Dialogue Response Text",
		ReturnValueString = "String", ReturnValueType = typeof(String_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Get the response text of the active Dialogue Node.")]
	public class DiaQ_DlgResTxt_plyBlock : String_Value
	{

		[plyBlockField("#", ShowName = true, ShowValue = true, DefaultObject = typeof(Int_Value), Description = "The index of response text to get. The responses are counted, starting at zero (0). The 2nd would be 1, the 3rd response 2, etc.")]
		public Int_Value idx;

		public override void Created()
		{
			blockIsValid = idx != null;
			if (!blockIsValid) Log(LogType.Error, "Response index must be set");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQNode_Dlg n = DiaQEngine.Instance.graphManager.NodeWaitingForData() as DiaQNode_Dlg;
			if (n != null)
			{
				int i = idx.RunAndGetInt();
				if (i < 0 || i >= n.responses.Length)
				{
					Log(LogType.Error, "The given response index is not valid for this dialogue node: " + i);
					return BlockReturn.Error;
				}
				//value = n.responses[i];
				value = n.ParsedResponseText(i);
			}
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}