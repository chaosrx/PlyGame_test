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
using DiaQ;

namespace DiaQ
{
	[plyBlock("Dialogue and Quest", "DiaQ", "Dialogue Text", BlockType.Variable, Order = 1, ShowIcon = "diaq", ShowName = "DiaQ Dialogue Text",
		ReturnValueString = "String", ReturnValueType = typeof(String_Value),
		Description = "Get the text of the active Dialogue Node.")]
	public class DiaQ_DlgText_plyBlock : String_Value
	{

		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQNode_Dlg n = DiaQEngine.Instance.graphManager.NodeWaitingForData() as DiaQNode_Dlg;
			if (n != null)
			{
				//value = n.dialogueText;
				//DiaQuest q = n.LinkedQuest();
				//if (q != null) value += q.text;
				value = n.ParsedDialogueText(true);
			}
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}