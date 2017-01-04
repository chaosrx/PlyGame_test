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
	[plyBlock("Dialogue and Quest", "DiaQ", "Get Quest at Idx", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "Get Quest",
		ReturnValueString = "SystemObject", ReturnValueType = typeof(SystemObject_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Returns a reference to a DiaQ Quest at the specified Index into the list of defined Quests. Lists index starts at 0 for the 1st entry and run up to 1 less than the value returned by the `Quest Count` Block.")]
	public class DiaQ_QuestAtIdx_plyBlock : SystemObject_Value
	{
		[plyBlockField("at", ShowName = true, ShowValue = true, Description = "Index into list of defined quests. Indices always starts at 0 and runs up to a max value of 1 less than the count of items in the list.")]
		public Int_Value idx;

		public override void Created()
		{
			blockIsValid = (idx != null);
			if (!blockIsValid) Log(LogType.Error, "The index field must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (DiaQEngine.Instance.questManager.quests.Count == 0)
			{
				Log(LogType.Error, "There are no quests defined.");
				return BlockReturn.Error;
			}

			int i = idx.RunAndGetInt();
			if (i < 0 || i >= DiaQEngine.Instance.questManager.quests.Count)
			{
				Log(LogType.Error, "The index ["+i+"] is invalid, it should be value between [0] and ["+(DiaQEngine.Instance.questManager.quests.Count-1)+"] inclusive.");
				return BlockReturn.Error;
			}

			value = DiaQEngine.Instance.questManager.quests[i];
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}