// -= plyBlox =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

#if UNITY_4_6 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9

using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace plyBloxKit
{
	[plyBlock("GUI", "uGUI", "Set Interactable", BlockType.Action, Order = 0,
		Description = "Set the UI Component of GameObject to be Interactable or not.")]
	public class uGUI_SetInteractable_plyBlock : plyBlock
	{
		[plyBlockField("Set Interactable =", SubName = "Value - Boolean", ShowName = true, ShowValue = true, EmptyValueName="-false-", DefaultObject = typeof(Bool_Value), Description = "The value to apply. Leaving this value empty will clear the target field.")]
		public Bool_Value val;

		[plyBlockField("on", SubName = "Target - GameObject or Component", ShowName = true, ShowValue = true, EmptyValueName="-self-", Description = "GameObject that has the component on it or you can specify a Component directly. If -self- then the GameObject of the Blox this Block is used in will be used.")]
		public plyValue_Block target;

		[plyBlockField("Cache target", Description = "Tell plyBlox if it can cache a reference to the Target Object, if you know it will not change, improving performance a little. This is done either way when the target is -self-")]
		public bool cacheTarget = false;

		private UnityEngine.UI.Selectable c = null; // cached component

		public override void Created()
		{
			blockIsValid = true;
			if (target == null) cacheTarget = true; // force cache when -self-
		}

		public override BlockReturn Run(BlockReturn param)
		{
			if (c == null)
			{
				object obj = (target == null ? owningBlox.gameObject : target.RunAndGetValue());
				GameObject go = obj as GameObject;

				if (go != null)
				{
					c = go.GetComponent<UnityEngine.UI.Selectable>();
					if (c == null)
					{
						Log(LogType.Error, "The component could not be found on the target object.");
						return BlockReturn.Error;
					}
				}
				else
				{
					c = obj as UnityEngine.UI.Selectable;
					if (c == null)
					{
						Log(LogType.Error, "The specified component is not valid.");
						return BlockReturn.Error;
					}
				}
			}

			c.interactable = (val == null ? false : val.RunAndGetBool());
			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}

#endif