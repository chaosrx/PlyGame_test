// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using plyBloxKit;

namespace DiaQ
{
	[plyEvent("DiaQ", "On Quest Completed",
		Description = "Called when a quest is completed.\n\n" +
		"- <b>questName</b>: (String) Name of the quest.\n"+
		"- <b>questIdent</b>: (String) Custom Ident of the quest.\n" +
		"- <b>questText</b>: (String) Text of the quest.\n" +
		"- <b>questObj</b>: (SystemObject) Reference to the Quest Object.\n"
	)]
	public class OnQuestCompletedEvent : plyEvent
	{

		public override System.Type HandlerType()
		{
			return typeof(DiaQEventHandler);
		}

		// ============================================================================================================
	}
}