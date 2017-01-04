﻿// -= plyRPG =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using plyCommon;
using plyBloxKit;
using plyGame;
using plyRPG;

namespace plyRPG
{
	[plyBlock("GUI", "plyRPG", "Show Dialogue", BlockType.Action, Order = 5,
		Description = "Show or Hide the Dialogue Panel.")]
	public class plyRPG_ShowDlg_Block : plyBlock
	{
		[plyBlockField("Option", ShowAfterField = "Dialogue Panel", ShowValue = true, CustomValueStyle = "plyBlox_BoldLabel")]
		public plyVisibleState2 val = plyVisibleState2.Show;

		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.ShowDialogue(val == plyVisibleState2.Show);
			return BlockReturn.OK;
		}

	}
}
