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
	[plyBlock("Dialogue and Quest", "DiaQ", "Has Waiting Node", BlockType.Condition, Order = 1, ShowIcon = "diaq", ShowName = "DiaQ Has Waiting Node",
		ReturnValueString = "Boolean", ReturnValueType = typeof(Bool_Value),
		Description = "Return True if there is a DiaQ Node that is waiting for data (player response). Returns null if no node is waiting for data or if no graph is running. This is normalyl used to check if there is a dialogue node that is waiting for player response.")]
	public class DiaQ_HasWaitingNode_plyBlock : Bool_Value
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			value = (DiaQEngine.Instance.graphManager.NodeWaitingForData() != null);
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}