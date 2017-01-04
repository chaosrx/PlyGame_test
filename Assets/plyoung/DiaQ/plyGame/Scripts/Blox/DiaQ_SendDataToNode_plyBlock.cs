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
	[plyBlock("Dialogue and Quest", "DiaQ", "Send Data to Node", BlockType.Action, Order = 1, ShowIcon = "diaq",
		Description = "Send data to a node. What the data is will depend on what node is currently active and waiting for data. This could be used to send an integer value to a waiting Dialogue node.")]
	public class DiaQ_SendDataToNode_plyBlock : plyBlock
	{

		[plyBlockField("Send Data to DiaQ Node", ShowName = true, ShowValue = true, Description = "The data type you send here will depend on what the waiting node is expecting to receive.")]
		public plyValue_Block val;

		public override void Created()
		{
			blockIsValid = val != null;
			if (!blockIsValid) Log(LogType.Error, "You must set all fields.");
		}

		public override BlockReturn Run(BlockReturn param)
		{
			DiaQEngine.Instance.graphManager.SendDataToNode(val.RunAndGetValue());
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}