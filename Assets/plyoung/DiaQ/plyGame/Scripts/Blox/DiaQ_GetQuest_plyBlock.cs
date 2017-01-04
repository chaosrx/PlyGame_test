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
	[plyBlock("Dialogue and Quest", "DiaQ", "Get Quest", BlockType.Variable, Order = 1, ShowIcon = "diaq",
		ReturnValueString = "SystemObject", ReturnValueType = typeof(SystemObject_Value), CustomStyle = "plyBlox_VarYellowDark",
		Description = "Returns a reference to a DiaQ Quest. Null if not found.")]
	public class DiaQ_GetQuest_plyBlock : SystemObject_Value
	{
		[plyBlockField("DiaQ Quest:", ShowIfTargetFieldInvalid = "questIdentNfo", ShowName = true, ShowValue = true, Description = "You can either select the Quest from a list or choose to identify it by its name or custom ident. Choose 'none' from the list to use the ident method and then add a String block in the provided space so that you can enter the name or custom ident as set up in the quest editor.")]
		public String_Value questStringIdent;

		[plyBlockField("DiaQ Quest", CustomValueStyle = "plyBlox_BoldLabel")]
		public DiaQuestFieldData questIdentNfo = new DiaQuestFieldData();

		[plyBlockField("ident type", ShowIfTargetFieldInvalid = "questIdentNfo", Description = "What kind of value did you enter to identify the Quest by?")]
		public DiaQIdentType identType = DiaQIdentType.Name;

		[plyBlockField("Cache target", Description = "Tell plyBlox that it can cache a reference to the quest, if you know it will not change, improving performance a little. This is done either way when you selected the Quest from a list.")]
		public bool cacheTarget = true;

		private DiaQuest quest = null;

		public override void Created()
		{
			blockIsValid = true;
		}

		public override void Initialise()
		{
			if (questIdentNfo.id < 0)
			{
				if (questStringIdent == null)
				{
					Log(LogType.Error, "Quest name/ ident is not set.");
					return;
				}
			}
			else
			{
				cacheTarget = true;
				questStringIdent = null;
			}
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (quest == null)
			{
				if (questStringIdent != null)
				{
					string s = questStringIdent.RunAndGetString();
					if (string.IsNullOrEmpty(s))
					{
						Log(LogType.Error, "Quest name/ ident is not set.");
						return BlockReturn.Error;
					}

					if (identType == DiaQIdentType.CutomIdent) quest = DiaQEngine.Instance.questManager.GetQuestByIdent(s);
					else quest = DiaQEngine.Instance.questManager.GetQuestByName(s);

					if (quest == null)
					{
						Log(LogType.Error, string.Format("Quest with {0} = {1} could not be found.", identType, s));
						return BlockReturn.Error;
					}

				}

				else
				{
					quest = DiaQEngine.Instance.questManager.GetQuestById(questIdentNfo.id);
					if (quest == null)
					{
						Log(LogType.Error, "Could not find the specified Quest. You might have removed it without updating the Block.");
						return BlockReturn.Error;
					}
				}
			}

			value = quest;
			if (!cacheTarget) quest = null;
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}