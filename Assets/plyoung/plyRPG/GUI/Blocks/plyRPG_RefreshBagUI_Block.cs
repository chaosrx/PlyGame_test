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
	[plyBlock("GUI", "plyRPG", "Refresh Bag UI", BlockType.Action, Order = 5, ShowName = "Refresh Bag UI",
		Description = "Call this to inform the UI that the bag slots has changed and UI should be updated to reflect these changes.")]
	public class plyRPG_RefreshBagUI_Block : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.RefreshBag();
			return BlockReturn.OK;
		}

	}
}
