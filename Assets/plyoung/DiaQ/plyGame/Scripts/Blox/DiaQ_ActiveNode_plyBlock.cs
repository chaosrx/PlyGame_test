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
	[plyBlock("Dialogue and Quest", "DiaQ", "Active Node", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "Active DiaQ Node",
		ReturnValueString = "SystemObject", ReturnValueType = typeof(SystemObject_Value),
		Description = "Returns a reference to the active DiaQ Node. Null if no node is active or no graph is running.")]
	public class DiaQ_ActiveNode_plyBlock : SystemObject_Value
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			value = DiaQEngine.Instance.graphManager.ActiveNode();
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}