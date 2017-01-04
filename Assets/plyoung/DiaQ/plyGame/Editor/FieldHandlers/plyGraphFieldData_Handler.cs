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
	[plyPropertyHandler(typeof(plyGraphFieldData))]
	public class plyGraphFieldData_Handler : plyBlockFieldHandler
	{

		public override object GetCopy(object obj)
		{
			plyGraphFieldData target = obj as plyGraphFieldData;
			if (target != null) return target.Copy();
			return new plyGraphFieldData();
		}

		public override void OnFocus(object obj, plyBlock fieldOfBlock)
		{
			plyGraphFieldData target = obj == null ? new plyGraphFieldData() : obj as plyGraphFieldData;
			plyGraphManager asset = DiaQEdGlobal.GraphsAsset;

			// check if saved still valid
			if (!string.IsNullOrEmpty(target.id))
			{
				bool found = false;
				UniqueID id = new UniqueID(target.id);
				for (int i = 0; i < asset.graphs.Count; i++)
				{
					if (id == asset.graphs[i].id) { found = true; break; }
				}
				if (!found)
				{
					target.id = "";
					target.cachedName = "";
					ed.ForceSerialise();
				}
			}
		}

		public override bool DrawField(ref object obj, plyBlock fieldOfBlock)
		{
			bool ret = (obj == null);
			plyGraphFieldData target = obj == null ? new plyGraphFieldData() : obj as plyGraphFieldData;
			plyGraphManager asset = DiaQEdGlobal.GraphsAsset;

			if (GUILayout.Button(string.IsNullOrEmpty(target.cachedName) ? "-select-" : target.cachedName))
			{
				List<object> l = new List<object>();
				for (int i = 0; i < asset.graphs.Count; i++) l.Add(new UniqueIdNamePair() { id = asset.graphs[i].id.Copy(), name = asset.graphs[i].name });
				plyListSelectWiz.ShowWiz("Select Graph", l, true, null, OnSelect, new object[] { ed, target });
			}

			obj = target;
			return ret;
		}

		private void OnSelect(object sender, object[] args)
		{
			plyGraphFieldData target = args[1] as plyGraphFieldData;
			plyBloxEd plyed = args[0] as plyBloxEd;

			plyListSelectWiz wiz = sender as plyListSelectWiz;
			UniqueIdNamePair uimp = wiz.selected as UniqueIdNamePair;
			wiz.Close();

			if (plyed == null || target == null) return;

			GUI.changed = true;
			if (uimp != null)
			{
				target.id = uimp.id.ToString();
				target.cachedName = uimp.name;
			}
			else
			{
				target.id = "";
				target.cachedName = "";
			}
			plyed.ForceSerialise();
			plyed.Repaint();
		}
		
		// ============================================================================================================
	}
}