// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyCommonEditor;
using plyBloxKit;
using plyBloxKitEditor;
using plyGame;
using plyGameEditor;
using DiaQ;

namespace DiaQEditor
{
	[plyPropertyHandler(typeof(DiaQuestFieldData))]
	public class DiaQuestFieldData_Handler : plyBlockFieldHandler
	{

		public override object GetCopy(object obj)
		{
			DiaQuestFieldData target = obj as DiaQuestFieldData;
			if (target != null) return target.Copy();
			return new DiaQuestFieldData();
		}

		public override void OnFocus(object obj, plyBlock fieldOfBlock)
		{
			DiaQuestFieldData target = obj == null ? new DiaQuestFieldData() : obj as DiaQuestFieldData;
			DiaQuestManager asset = DiaQEdGlobal.QuestsAsset;

			// check if saved still valid
			if (target.id >= 0)
			{
				bool found = false;
				for (int i = 0; i < asset.quests.Count; i++)
				{
					if (target.id == asset.quests[i].id) { found = true; break; }
				}
				if (!found)
				{
					target.id = -1;
					target.cachedName = "";
					ed.ForceSerialise();
				}
			}
		}

		public override bool DrawField(ref object obj, plyBlock fieldOfBlock)
		{
			bool ret = (obj == null);
			DiaQuestFieldData target = obj == null ? new DiaQuestFieldData() : obj as DiaQuestFieldData;
			DiaQuestManager asset = DiaQEdGlobal.QuestsAsset;

			if (GUILayout.Button(string.IsNullOrEmpty(target.cachedName) ? "-select-" : target.cachedName))
			{
				List<object> l = new List<object>();
				for (int i = 0; i < asset.quests.Count; i++) l.Add(new IntIdNamePair() { id = asset.quests[i].id, name = asset.quests[i].name });
				plyListSelectWiz.ShowWiz("Select Quest", l, true, null, OnSelect, new object[] { ed, target });
			}

			obj = target;
			return ret;
		}

		private void OnSelect(object sender, object[] args)
		{
			DiaQuestFieldData target = args[1] as DiaQuestFieldData;
			plyBloxEd plyed = args[0] as plyBloxEd;

			plyListSelectWiz wiz = sender as plyListSelectWiz;
			IntIdNamePair uimp = wiz.selected as IntIdNamePair;
			wiz.Close();

			if (plyed == null || target == null) return;

			GUI.changed = true;
			if (uimp != null)
			{
				target.id = uimp.id;
				target.cachedName = uimp.name;
			}
			else
			{
				target.id = -1;
				target.cachedName = "";
			}
			plyed.ForceSerialise();
			plyed.Repaint();
		}
		
		// ============================================================================================================
	}
}