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
	[plyBlock("Dialogue and Quest", "DiaQ", "Give Quest Rewards", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Will run through a Quest's rewards and give the player the rewards. Will only work where reward givers are registered and not with any custom keys. Will force quest to Accepted, Completed and Rewarded status.")]
	public class DiaQ_GiveQuestRewards_plyBlock : plyBlock
	{
		[plyBlockField("Perform Quest", ShowAfterField="Rewards", ShowName = true, ShowValue = true, DefaultObject=typeof(DiaQ_GetQuest_plyBlock), SubName="Target - SystemObject (Quest)", Description = "The quest for which to give the rewards.")]
		public SystemObject_Value q;

		public override void Created()
		{
			blockIsValid = q != null;
			if (!blockIsValid) Log(LogType.Error, "The Quest field must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQuest quest = q.RunAndGetSystemObject() as DiaQuest;
			if (quest == null)
			{
				Log(LogType.Error, "A valid quest was not specified.");
				return BlockReturn.Error;
			}

			quest.rewarded = true;
			quest.RunRewardGivers();

			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}