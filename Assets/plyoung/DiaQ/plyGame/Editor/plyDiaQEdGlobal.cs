// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using plyCommonEditor;
using plyBloxKitEditor;
using plyGameEditor;
using plyGame;
using plyCommon;
using DiaQ;

namespace DiaQEditor
{
	[InitializeOnLoad]
	public class plyDiaQEdGlobal
	{

		static plyDiaQEdGlobal()
		{
			EditorApplication.update += RunOnce;
		}

		private static void RunOnce()
		{
			EditorApplication.update -= RunOnce;
			
			EdGlobal.RegisterPlugin(
						new plyGamePluginInfo()
						{
							name = "DiaQ by PL Young",
							versionFile = "plyoung/DiaQ/Documentation/version.txt",
						}
					);

			plyBloxGUI.blockIcons.Add("diaq", plyEdGUI.LoadEditorTexture(plyEdUtil.PackagesRelativePathStart() + "DiaQ/plyGame/edRes/Icons/diaq.png"));
			RegisterDefaultToolButtons();
			EdGlobal.RegisterAutoCreate(DiaQEdGlobal.Prefab);

			// make sure the Prefab has the LoadSave related components on it else plyGame can't load/ save the DiaQ Data during runtime
			DiaQLoadSaveInterface ls = DiaQEdGlobal.Prefab.GetComponent<DiaQLoadSaveInterface>();
			if (ls == null)
			{
				DiaQEdGlobal.Prefab.AddComponent<DiaQLoadSaveInterface>();
				EditorUtility.SetDirty(DiaQEdGlobal.Prefab);
			}

		}

		private static void RegisterDefaultToolButtons()
		{
			EdToolbar.AddToolbarButtons(new System.Collections.Generic.List<EdToolbar.ToolbarButton>()
			{
				new EdToolbar.ToolbarButton() { order = 200, callback = OpenDiaQEditor, gui = new GUIContent(plyEdGUI.LoadEditorTexture(plyEdUtil.PackagesRelativePathStart() + "DiaQ/plyGame/edRes/Toolbar/diaq" + (EditorGUIUtility.isProSkin ? "" : "_l") + ".png"), "DiaQ") },
			});
		}

		public static void OpenDiaQEditor()
		{
			DiaQEd.ShowDiaQEditorWindow();
		}

		// ============================================================================================================
	}
}