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
	[plyBlock("Dialogue and Quest", "DiaQ", "Update Quest Condition", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Update a Quest Conditions of specified Key with Value. This affects all quests conditions that uses the same condition key. This will only affect conditions of 'accepted' quests.")]
	public class DiaQ_UpdCond_plyBlock : plyBlock
	{
		[plyBlockField("Update Quest Condition", ShowName = true, ShowValue = true, DefaultObject = typeof(String_Value), SubName = "Condition Key - String", Description = "Conditions with this Key will be affected.")]
		public String_Value key;

		[plyBlockField("with", ShowName = true, ShowValue = true, DefaultObject = typeof(Int_Value), SubName="Value - Integer", Description = "The value to update the key with. You normally pass a positive number here but a negative value can be used if you want to subtract from the condition's current value. Note that it will not be prevented to go below zero.")]
		public Int_Value val;

		public override void Created()
		{
			blockIsValid = key != null && val != null;
			if (!blockIsValid) Log(LogType.Error, "The Key and Value fields must be set.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQEngine.Instance.questManager.ConditionPerformed(key.RunAndGetString(), val.RunAndGetInt());
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}