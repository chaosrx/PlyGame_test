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
using plyCommonEditor.FontAwesome;
using plyBloxKit;
using plyBloxKitEditor;

namespace DiaQ
{
	[plyNodeEd("DiaQ", "Trigger Event", typeof(DiaQNode_BloxEvent))]
	public class DiaQNodeEd_BloxEvent : plyNodeEditorBase
	{
		private GUIContent c;
		private GUIStyle outStyle;

		public DiaQNodeEd_BloxEvent()
		{
			toolbarButton = new GUIContent(FA.cube.ToString(), "Trigger Event");
		}

		public override string NodeWindowLabel(plyNode node)
		{
			return "Trigger Event";
		}

		public override GUILayoutOption[] OutLabelLayoutOptions(plyNode node, int idx)
		{
			return null;
		}

		public override GUIStyle OutLabelStyle(plyNode node, int idx)
		{
			if (outStyle == null) outStyle = new GUIStyle(plyGraphGUI.NodeOutLinkLabelStyle) { wordWrap = false };
			return outStyle;
		}

		public override GUIContent OutLinkLabel(plyNode node, int idx)
		{
			DiaQNode_BloxEvent Target = node as DiaQNode_BloxEvent;
			if (c == null) c = new GUIContent();
			if (Target.targetObjType == DiaQNode_BloxEvent.TargetObjectType.Self) c.text = "Self.";
			else if (Target.targetObjType == DiaQNode_BloxEvent.TargetObjectType.Active) c.text = "Active.";
			else c.text = Target.targetObjType + "(" + Target.targetObjTypeData + ").";
			c.text += Target.eventName; // +"(" + plyDataObjectEditor.GetPrettyName(Target.val, "") + ")";
			return c;
		}

		// ============================================================================================================

		public override bool RenderNodeInspector(plyNode node, BasicCallback repaintCallback, BasicCallback saveCallback)
		{
			DiaQNode_BloxEvent Target = node as DiaQNode_BloxEvent;
			bool dirty = false;

			EditorGUI.BeginChangeCheck();
			GUILayout.Label("Get Target Object");
			EditorGUI.indentLevel++;
			Target.targetObjType = (DiaQNode_BloxEvent.TargetObjectType)EditorGUILayout.EnumPopup("by", Target.targetObjType);
			if (Target.targetObjType != DiaQNode_BloxEvent.TargetObjectType.Active && Target.targetObjType != DiaQNode_BloxEvent.TargetObjectType.Self) Target.targetObjTypeData = EditorGUILayout.TextField(" ", Target.targetObjTypeData);
			if (Target.targetObjType == DiaQNode_BloxEvent.TargetObjectType.Self)
			{
				if (plyEdGUI.LabelButton("", "Edit Event on Self", (int)EditorGUIUtility.labelWidth - 5, 0))
				{
					plyBlox b = graphEd.graphEd.asset.gameObject.GetComponent<plyBlox>();
					if (b == null)
					{
						b = graphEd.graphEd.asset.gameObject.AddComponent<plyBlox>();
						saveCallback();
					}
					if (b != null)
					{
						Selection.activeObject = b.gameObject;
						EditorGUIUtility.PingObject(Selection.activeObject);
						plyBloxEd.Show_plyBloxEd(b, "DiaQ");
					}
					else Debug.LogError("Failed to find or attach a plyBlox object to the DiaQ prefab.");
				}
			}
			EditorGUI.indentLevel--;

			EditorGUILayout.Space();
			GUILayout.Label("Trigger Event");
			EditorGUI.indentLevel++;
			Target.eventName = EditorGUILayout.TextField("with name", Target.eventName);
			if (EditorGUI.EndChangeCheck()) dirty = true;

			//EditorGUILayout.BeginHorizontal();
			//{
			//	EditorGUILayout.PrefixLabel("and value");
			//	if (plyDataObjectEditor.DrawField(ref Target.val, "data", repaintCallback, saveCallback)) dirty = true;
			//}
			//EditorGUILayout.EndHorizontal();
			EditorGUI.indentLevel--;

			return dirty;
		}

		// ============================================================================================================
	}
}
