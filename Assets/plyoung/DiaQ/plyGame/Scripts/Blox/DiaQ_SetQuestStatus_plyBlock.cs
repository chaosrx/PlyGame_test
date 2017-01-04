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
	[plyBlock("Dialogue and Quest", "DiaQ", "Set Quest Status", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Force the Quest to a specific Status.")]
	public class DiaQ_SetQuestStatus_plyBlock : plyBlock
	{
		[plyBlockField("Set Quest", ShowName = true, ShowValue = true, SubName="Target - SystemObject (Quest)", DefaultObject=typeof(DiaQ_GetQuest_plyBlock), Description = "The quest for which to change status.")]
		public SystemObject_Value q;

		public enum State { Available, Accepted, Rewarded, Completed }
		[plyBlockField("to", ShowName = true, ShowValue = true, CustomValueStyle = "plyBlox_BoldLabel", Description = "State to set quest to.")]
		public State st = State.Available;

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

			switch (st)
			{
				case State.Available: quest.ResetQuest(); break;
				case State.Accepted: quest.ResetQuestToAccepted(); break;
				case State.Completed: quest.completed = true; break;
				case State.Rewarded: quest.rewarded = true; break;
			}

			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}