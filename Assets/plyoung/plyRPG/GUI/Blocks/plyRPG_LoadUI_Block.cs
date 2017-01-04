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
	[plyBlock("GUI", "plyRPG", "Load UI", BlockType.Action, Order = 5, ShowName = "Load RPG UI",
		Description = "Load the RPG module's default runtime UI.")]
	public class plyRPG_LoadUI_Block : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			plyRPG_UI.Load();
			return BlockReturn.OK;
		}

	}
}
