// -= plyBlox =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

#if UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9

using UnityEngine;

namespace plyBloxKit
{
	[plyBlock("GUI", "uGUI", "Add DropDown Option", BlockType.Action, Order = 0,
		Description = "Get an option to a DropDown UI Component of GameObject.")]
	public class uGUI_AddDropDownOption_plyBlock : plyBlock
	{
		[plyBlockField("Add", SubName = "Option Text - String", ShowName = true, ShowValue = true, EmptyValueName = "-no-text-", Description = "Text/Name of new option")]
		public String_Value text;

		[plyBlockField("and", SubName = "Option Sprite - Sprite", ShowName = true, ShowValue = true, EmptyValueName = "-none-", Description = "[optional] Sprite of new option")]
		public UnityObject_Value img;

		[plyBlockField("to DropDown", SubName = "Target - GameObject or Component", ShowName = true, ShowValue = true, EmptyValueName = "-self-", Description = "GameObject that has the component on it or you can specify a Component directly. If -self- then the GameObject of the Blox this Block is used in will be used.")]
		public plyValue_Block target;

		[plyBlockField("Cache target", Description = "Tell plyBlox if it can cache a reference to the Target Object, if you know it will not change, improving performance a little. This is done either way when the target is -self-")]
		public bool cacheTarget = false;

		private UnityEngine.UI.Dropdown c = null; // cached component

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
					c = go.GetComponent<UnityEngine.UI.Dropdown>();
					if (c == null)
					{
						Log(LogType.Error, "The component could not be found on the target object.");
						return BlockReturn.Error;
					}
				}
				else
				{
					c = obj as UnityEngine.UI.Dropdown;
					if (c == null)
					{
						Log(LogType.Error, "The specified component is not valid.");
						return BlockReturn.Error;
					}
				}
			}

			string s = text == null ? null : text.RunAndGetString();
			Sprite sp = img == null ? null : img.RunAndGetUnityObject() as Sprite;

			if (s != null && sp != null) c.options.Add(new UnityEngine.UI.Dropdown.OptionData(s, sp));
			else if (s != null) c.options.Add(new UnityEngine.UI.Dropdown.OptionData(s));
			else if (sp != null) c.options.Add(new UnityEngine.UI.Dropdown.OptionData(sp));
			else
			{
				Log(LogType.Error, "You need to specify at least the text/name or sprite to use.");
				return BlockReturn.Error;
			}

			return BlockReturn.OK;
		}

		// ============================================================================================================
	}
}

#endif