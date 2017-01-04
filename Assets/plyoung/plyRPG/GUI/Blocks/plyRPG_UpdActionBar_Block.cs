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
	[plyBlock("GUI", "plyRPG", "Update Action Bar", BlockType.Action, Order = 5, ShowName = "Update Action Bar",
		Description = "Update the action bar.")]
	public class plyRPG_UpdActionBar_Block : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.UpdateActionBar();
			return BlockReturn.OK;
		}

	}
}
