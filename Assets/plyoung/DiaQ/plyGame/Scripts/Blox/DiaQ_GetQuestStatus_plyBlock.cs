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
	[plyBlock("Dialogue and Quest", "DiaQ", "Get Quest Status", BlockType.Variable, Order = 1, ShowIcon = "diaq",
		ReturnValueString = "Integer", ReturnValueType = typeof(Int_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Returns the status of a DiaQ Quest.\n0: Not accepted\n1: Accepted\n2: Completed\n3: Rewarded")]
	public class DiaQ_GetQuestStatus_plyBlock : Int_Value
	{
		[plyBlockField("Status of", ShowName = true, ShowValue = true, DefaultObject=typeof(DiaQ_GetQuest_plyBlock), Description="The quest to check.")]
		public SystemObject_Value target;

		[plyBlockField("Cache target", Description = "Tell plyBlox that it can cache a reference to the quest, if you know it will not change, improving performance a little. Do not set this true if the quest specified in the quest field can change during runtime.")]
		public bool cacheTarget = false;

		private DiaQuest quest = null;

		public override void Created()
		{
			blockIsValid = target != null;
			if (!blockIsValid) Log(LogType.Error, "The quest must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (quest == null)
			{
				quest = target.RunAndGetSystemObject() as DiaQuest;
				if (quest == null)
				{
					Log(LogType.Error, "The quest is not valid.");
					return BlockReturn.Error;
				}
			}

			if (quest.rewarded) value = 3;
			else if (quest.completed) value = 2;
			else if (quest.accepted) value = 1;
			else value = 0;

			if (!cacheTarget) quest = null;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}