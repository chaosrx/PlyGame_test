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
	[plyBlock("Dialogue and Quest", "DiaQ", "Stop Graph", BlockType.Action, Order = 1, ShowIcon = "diaq", ShowName = "Stop DiaQ Graph",
		Description = "Stop any active Graph.")]
	public class DiaQ_StopGraph_plyBlock : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQEngine.Instance.graphManager.StopGraph();
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}