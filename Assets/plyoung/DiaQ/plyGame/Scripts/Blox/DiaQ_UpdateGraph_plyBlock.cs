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

namespace DiaQ
{
	[plyBlock("Dialogue and Quest", "DiaQ", "Update Graph", BlockType.Action, Order = 1, ShowIcon = "diaq", ShowName = "Update DiaQ Graph",
		Description = "Used to force the active Graph to update. Useful when you responded to a waiting node and can't wait till the next Update before checking for new data from the Graph.")]
	public class DiaQ_UpdateGraph_plyBlock : plyBlock
	{
		public override void Created()
		{
			blockIsValid = true;
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQEngine.Instance.graphManager.UpdateGraph();
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}