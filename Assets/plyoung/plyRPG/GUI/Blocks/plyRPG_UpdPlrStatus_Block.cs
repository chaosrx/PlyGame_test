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
	[plyBlock("GUI", "plyRPG", "Update Player Status", BlockType.Action, Order = 5, ShowName = "Update Player Status",
		Description = "Update the status bars of Player.")]
	public class plyRPG_UpdPlrStatus_Block : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.UpdatePlayerStatus();
			return BlockReturn.OK;
		}

	}
}
