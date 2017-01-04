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
	[plyBlock("Dialogue and Quest", "DiaQ", "Perform Quest Condition", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Tell the Quest Manager that the Quest Condition was performed once. This will increase the value of all conditions with the same key, by one. This will only affect conditions of 'accepted' quests.")]
	public class DiaQ_PerfCond_plyBlock : plyBlock
	{
		[plyBlockField("Perform Quest Condition", ShowName = true, ShowValue = true, DefaultObject = typeof(String_Value), SubName = "Condition Key - String", Description = "Conditions with this Key will be affected.")]
		public String_Value key;

		public override void Created()
		{
			blockIsValid = key != null;
			if (!blockIsValid) Log(LogType.Error, "The Key field must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQEngine.Instance.questManager.ConditionPerformed(key.RunAndGetString());
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}