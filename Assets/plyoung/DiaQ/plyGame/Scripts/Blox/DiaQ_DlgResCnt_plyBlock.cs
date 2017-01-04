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
	[plyBlock("Dialogue and Quest", "DiaQ", "Dialogue Response Count", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "DiaQ Dialogue Response Count",
		ReturnValueString = "Integer", ReturnValueType = typeof(Int_Value),
		Description = "Return how many responses the active Dialogue Node has.")]
	public class DiaQ_DlgResCnt_plyBlock : Int_Value
	{

		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQNode_Dlg n = DiaQEngine.Instance.graphManager.NodeWaitingForData() as DiaQNode_Dlg;
			if (n != null) value = n.responses.Length;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}