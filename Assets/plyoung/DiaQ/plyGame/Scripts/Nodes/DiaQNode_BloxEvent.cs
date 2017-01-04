// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyBloxKit;

namespace DiaQ
{
	public class DiaQNode_BloxEvent : plyNode
	{
		// ============================================================================================================
		#region properties

		/// <summary> How to find the GameObject </summary>
		public enum TargetObjectType
		{
			/// <summary> by its name </summary>
			Name,
			/// <summary> by its tag </summary>
			Tag,
			/// <summary> by type of component it has. expected to be unique </summary>
			Type,
			/// <summary> it is whatever the plyGraph.activeGO static is set to at the time </summary>
			Active,
			/// <summary> is the instance of the GraphManager's GameObject in the scene </summary>
			Self,
		}

		/// <summary> How to find the GameObject that the Blox is on </summary>
		public TargetObjectType targetObjType = TargetObjectType.Self;

		/// <summary> The name, tag or component type </summary>
		public string targetObjTypeData = "";

		/// <summary> The name of the event to trigger </summary>
		public string eventName = "";

		private System.Type findType = null; // cached type

		#endregion
		// ============================================================================================================
		#region pub

		public override string PrettyName()
		{
			return "Trigger Event";
		}

		public override void OnAddedToGraph()
		{
			base.OnAddedToGraph();
			__rect.width = 120;
		}

		public override void CopyTo(plyNode n)
		{
			base.CopyTo(n);
			DiaQNode_BloxEvent o = n as DiaQNode_BloxEvent;

			o.targetObjType = this.targetObjType;
			o.targetObjTypeData = this.targetObjTypeData;
			o.eventName = this.eventName;
		}

		public override int Enter()
		{
			GameObject go = GetGameObject();
			if (go != null)
			{
				plyBlox b = go.GetComponent<plyBlox>();
				if (b != null)
				{
					plyEvent e = b.GetEvent(eventName);
					if (e != null)
					{
						b.RunEvent(e);
					}
					else LogError(string.Format("No Event named [{0}] found in plyBlox of: {1} :: {2}", eventName, targetObjType, targetObjTypeData));
				}
				else LogError(string.Format("No plyBlox component found on the target: {0} :: {1}", targetObjType, targetObjTypeData));
			}
			else
			{
				LogError(string.Format("Could not find object {0} :: {1}", targetObjType, targetObjTypeData));
				return (int)ReturnCode.Stop;
			}

			return 0; // to next node
		}

		private GameObject GetGameObject()
		{
			if (targetObjType == TargetObjectType.Self) return owningGraph.owningGraphManager.gameObject;
			else if (targetObjType == TargetObjectType.Active) return plyGraph.activeGO;
			else if (targetObjType == TargetObjectType.Name) return GameObject.Find(targetObjTypeData);
			else if (targetObjType == TargetObjectType.Tag) return GameObject.FindWithTag(targetObjTypeData);
			else if (targetObjType == TargetObjectType.Type)
			{
				if (findType == null) findType = plyReflectionUtil.FindType(targetObjTypeData);
				if (findType != null)
				{
					Component c = Object.FindObjectOfType(findType) as Component;
					if (c != null) return c.gameObject;
				}
			}
			return null;
		}

		#endregion
		// ============================================================================================================
	}
}
