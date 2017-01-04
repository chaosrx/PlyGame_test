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
	[plyBlock("GUI", "plyRPG", "Show Bag", BlockType.Action, Order = 5,
		Description = "Show or Hide the Player's Bag.")]
	public class plyRPG_ShowBag_Block : plyBlock
	{
		[plyBlockField("Option", ShowAfterField = "Player Bag", ShowValue = true, CustomValueStyle = "plyBlox_BoldLabel")]
		public plyVisibleState2 val = plyVisibleState2.Show;

		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.ShowBag(val == plyVisibleState2.Show);
			return BlockReturn.OK;
		}

	}
}
