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
	[plyBlock("Dialogue and Quest", "DiaQ", "Active Graph", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "Active DiaQ Graph",
		ReturnValueString = "SystemObject", ReturnValueType = typeof(SystemObject_Value),
		Description = "Returns a reference to the active DiaQ Graph. Null if none active.")]
	public class DiaQ_ActiveGraph_plyBlock : SystemObject_Value
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			value = DiaQEngine.Instance.graphManager.ActiveGraph();
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}