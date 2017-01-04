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
	[plyBlock("Dialogue and Quest", "DiaQ", "Quest Count", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "Quest Count",
		ReturnValueString = "Integer", ReturnValueType = typeof(Int_Value),
		Description = "Returns how may Quests are defined. This could be used with a Loop Block and the `Get Quest at Index` Block to process all defined quests.")]
	public class DiaQ_QstCnt_plyBlock : Int_Value
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			value = DiaQEngine.Instance.questManager.quests.Count;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}