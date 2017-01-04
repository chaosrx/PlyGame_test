// -= plyRPG =-
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
	[plyBlock("GUI", "plyRPG", "Show Quest Log", BlockType.Action, Order = 5,
		Description = "Show or Hide the Quest Log panel.")]
	public class plyRPG_ShowQstLog_Block : plyBlock
	{
		[plyBlockField("Option", ShowAfterField = "Quest Log", ShowValue = true, CustomValueStyle = "plyBlox_BoldLabel")]
		public plyVisibleState2 val = plyVisibleState2.Show;

		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.ShowQuestLog(val == plyVisibleState2.Show);
			return BlockReturn.OK;
		}

	}
}
