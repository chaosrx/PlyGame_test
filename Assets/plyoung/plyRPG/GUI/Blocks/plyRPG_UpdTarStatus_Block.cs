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
	[plyBlock("GUI", "plyRPG", "Update Target Status", BlockType.Action, Order = 5, ShowName = "Update Target Status",
		Description = "Update the status bars of Player's Target.")]
	public class plyRPG_UpdTarStatus_Block : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Instance.UpdateTargetStatus();
			return BlockReturn.OK;
		}

	}
}
