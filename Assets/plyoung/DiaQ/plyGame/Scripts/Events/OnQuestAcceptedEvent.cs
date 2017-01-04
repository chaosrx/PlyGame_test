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
	[plyEvent("DiaQ", "On Quest Accepted",
		Description = "Called when a quest is accepted.\n\n" +
		"- <b>questName</b>: (String) Name of the quest.\n"+
		"- <b>questIdent</b>: (String) Custom Ident of the quest.\n" +
		"- <b>questText</b>: (String) Text of the quest.\n" +
		"- <b>questObj</b>: (SystemObject) Reference to the Quest Object.\n"
	)]
	public class OnQuestAcceptedEvent : plyEvent
	{

		public override System.Type HandlerType()
		{
			return typeof(DiaQEventHandler);
		}

		// ============================================================================================================
	}
}