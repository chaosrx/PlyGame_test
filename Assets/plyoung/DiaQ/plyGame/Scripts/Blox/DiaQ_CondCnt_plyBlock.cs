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
	[plyBlock("Dialogue and Quest", "DiaQ", "Quest Condition Count", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "Count DiaQ Quest Conditions",
		ReturnValueString = "Integer", ReturnValueType = typeof(Int_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Returns how may Conditions are defined in the specified Quest.")]
	public class DiaQ_CondCnt_plyBlock : Int_Value
	{
		[plyBlockField("in", ShowName = true, ShowValue = true, DefaultObject=typeof(DiaQ_GetQuest_plyBlock), Description="The quest to get the conditions count from.")]
		public SystemObject_Value target;

		public override void Created()
		{
			blockIsValid = target != null;
			if (!blockIsValid) Log(LogType.Error, "The quest must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQuest quest = target.RunAndGetSystemObject() as DiaQuest;
			if (quest == null)
			{
				Log(LogType.Error, "The quest is not valid.");
				return BlockReturn.Error;
			}

			value = quest.conditions.Count;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}