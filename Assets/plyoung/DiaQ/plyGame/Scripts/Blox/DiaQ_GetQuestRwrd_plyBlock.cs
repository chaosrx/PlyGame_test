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
	[plyBlock("Dialogue and Quest", "DiaQ", "Get Quest Reward", BlockType.Variable, Order = 1, ShowIcon = "diaq",
		ReturnValueString = "SystemObject", ReturnValueType = typeof(SystemObject_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Returns a reference to a DiaQ Quest Reward.")]
	public class DiaQ_GetQuestRwrd_plyBlock : SystemObject_Value
	{
		[plyBlockField("DiaQ Quest Reward", ShowName = true, ShowValue = true, DefaultObject = typeof(Int_Value), SubName = "Index - Integer", Description = "The index (position) of the reward in the list of rewards. Indexing starts at 0, so the 1st would be 0, the 2nd condition would be 1, etc.")]
		public Int_Value idx;

		[plyBlockField("in", ShowName = true, ShowValue = true, DefaultObject=typeof(DiaQ_GetQuest_plyBlock), Description="The quest that the reward should be found in.")]
		public SystemObject_Value target;

		[plyBlockField("Cache target", Description = "Tell plyBlox that it can cache a reference to the reward, if you know it will not change, improving performance a little. Do not set this true if the index field value will be changing.")]
		public bool cacheTarget = false;

		private DiaQuestReward reward = null;

		public override void Created()
		{
			blockIsValid = target != null && idx != null;
			if (!blockIsValid) Log(LogType.Error, "The quest and index must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (reward == null)
			{
				DiaQuest quest = target.RunAndGetSystemObject() as DiaQuest;
				if (quest == null)
				{
					Log(LogType.Error, "The quest is not valid.");
					return BlockReturn.Error;
				}

				int c = idx.RunAndGetInt();
				if (c < 0 || c >= quest.rewards.Count)
				{
					Log(LogType.Error, "Index is invalid. It must be >= 0 and < quest reward count");
					return BlockReturn.Error;
				}

				reward = quest.rewards[c];
			}

			value = reward;
			if (!cacheTarget) reward = null;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}