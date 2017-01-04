// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyGame;
using DiaQ;
using plyCommonEditor;
using plyCommonEditor.FontAwesome;
using plyGameEditor;

namespace DiaQEditor
{
	public class plyRPGDiaQRewardInfo : plyDataProviderInfo
	{
		public plyRPGDiaQRewardInfo()
		{
			GC_BACK = new GUIContent(FA.arrow_circle_o_left.ToString() + " Back");
		}

		/// <summary> Unique name to identify the provider by </summary>
		public override string ProviderName()
		{
			return "plyRPG";
		}

		/// <summary> Context is important to identify where this provider can be used.
		/// The default is "data", meaning it can provider data and is able to set 
		/// its data. That is, it implements DataProvider_GetValue and DataProvider_SetValue.
		/// Where a system, using DataProviders, are more specialised it will indicate what
		/// context it expects if it do not function purely on get/set of data. </summary>
		public override string ProviderContext()
		{
			return "DiaQReward";
		}

		/// <summary> Return a nice name that identifies the data. Shown in the button
		/// used to open the data provider editor window for setup. </summary>
		public override string PrettyName(plyDataObject data, string emptyText)
		{
			if (data.nfo[0] == "0") return "Currency";
			return string.IsNullOrEmpty(data.nfo[2]) ? "-error-" : data.nfo[2];
		}

		/// <summary> Init the target type with this when the provider is selected </summary>
		public override plyDataObject.TargetObjectType DefaultTargetType()
		{
			return plyDataObject.TargetObjectType.Name;
		}

		/// <summary> Init the target type data this when the provider is selected </summary>
		public override string DefaultTargetTypeData()
		{
			// At runtime "plyRPGDiaQRewardHandler" is placed onto the DiaQ GameObject because I use
			// EdGlobal.RegisterAutoComponent("DiaQ", "plyRPGDiaQRewardHandler"); to make sure it
			// will automatically attach to that GameObject
			return "DiaQ";
		}

		/// <summary> Init the component name with this when the provider is selected.
		/// It is the component that implements plyDataProviderInterface </summary>
		public override string DefaultComponent()
		{
			// this will be the component who's DataProvider_Callback() is called
			return "plyRPGDiaQRewardHandler";
		}

		/// <summary> Init the the nfo[] field with this when the provider is selected </summary>
		public override string[] InitNfo()
		{
			// init nfo[] with two strings needed to carry the needed info
			// nfo[0] = 0:Currency, 1:Attribute, 2:Item
			// nfo[1] = the identifier of the attribute or item (not used with currency selected)
			// nfo[2] = cached name of selected attribute or item
			return new string[] { "0", "-1", "" };
		}

		/// <summary> Return true if user may choose different settings for type and type data in editor </summary>
		public override bool CanChangeType()
		{
			return false;
		}

		// ============================================================================================================

		private static GUIContent GC_BACK;
		private static string[] Options = { "Currency", "Attribute", "Item", };
		private int selected = 0;
		private int selectedIdent = -1;
		private DataAsset dataAsset;
		private ActorAttributesAsset attribsAsset;
		private ItemsAsset itemsAsset;
		private string[] attribNames = new string[0];
		private bool selectingItem = false;
	
		/// <summary> Called when the data provider is selected </summary>
		public override void NfoFieldFocus(plyDataObject data, EditorWindow ed)
		{
			// make sure the Component that handles the Rewards is registered to be added to DiaQ
			#if UNITY_4_6
			EdGlobal.RegisterAutoComponent("DiaQ", "plyRPGDiaQRewardHandler");
			#else
			EdGlobal.RemoveAutoComponent("DiaQ", "plyRPGDiaQRewardHandler"); // make sure old one is not present as it causes problems
			EdGlobal.RegisterAutoComponent("DiaQ", typeof(DiaQ.plyRPGDiaQRewardHandler).AssemblyQualifiedName);
			#endif

			selected = 0;
			int.TryParse(data.nfo[0], out selected);

			if (attribsAsset == null)
			{
				if (dataAsset == null) dataAsset = EdGlobal.GetDataAsset();
				attribsAsset = (ActorAttributesAsset)dataAsset.GetAsset<ActorAttributesAsset>();
				if (attribsAsset == null) attribsAsset = (ActorAttributesAsset)EdGlobal.LoadOrCreateAsset<ActorAttributesAsset>(plyEdUtil.DATA_PATH_SYSTEM + "attributes.asset", null);
			}

			if (itemsAsset == null)
			{
				if (dataAsset == null) dataAsset = EdGlobal.GetDataAsset();
				itemsAsset = (ItemsAsset)dataAsset.GetAsset<ItemsAsset>();
				if (itemsAsset == null) itemsAsset = (ItemsAsset)EdGlobal.LoadOrCreateAsset<ItemsAsset>(plyEdUtil.DATA_PATH_SYSTEM + "items.asset", null);
				itemsAsset.UpdateItemCache();
			}

			selectedIdent = -1;
			attribNames = new string[attribsAsset.attributes.Count];
			for (int i = 0; i < attribsAsset.attributes.Count; i++)
			{
				attribNames[i] = attribsAsset.attributes[i].def.screenName;
				if (selected == 1 && selectedIdent < 0)
				{
					if (data.nfo[1].Equals(attribsAsset.attributes[i].id.ToString()))
					{
						selectedIdent = i;
						data.nfo[2] = attribsAsset.attributes[selectedIdent].ToString(); // update cached name just in case it has changed
						GUI.changed = true;
					}
				}
			}

			if (data.nfo[0] == "2")
			{
				if (null == itemsAsset.GetDefinition(new UniqueID(data.nfo[1])))
				{
					data.nfo[1] = "";
					data.nfo[2] = "";
					GUI.changed = true;
				}
			}
		}

		/// <summary> Called when the nfo[] edit fields should be rendered </summary>
		public override void NfoField(plyDataObject data, EditorWindow ed)
		{
			// nfo[0] = 0:Currency, 1:Attribute, 2:Item
			// nfo[1] = the identifier of the attribute or item.(not used with currency selected)
			// nfo[2] = cached name of selected attribute or item

			if (selectingItem)
			{
				ShowSelectItem(data);
				return;
			}

			EditorGUI.BeginChangeCheck();
			selected = EditorGUILayout.Popup("Reward Type", selected, Options);
			if (EditorGUI.EndChangeCheck())
			{
				data.nfo[0] = selected.ToString();
				data.nfo[1] = "-1";
				data.nfo[2] = "";
			}

			if (selected == 1)
			{
				EditorGUI.BeginChangeCheck();
				selectedIdent = EditorGUILayout.Popup(" ", selectedIdent, attribNames);
				if (EditorGUI.EndChangeCheck())
				{
					data.nfo[1] = attribsAsset.attributes[selectedIdent].id.ToString();
					data.nfo[2] = attribsAsset.attributes[selectedIdent].def.screenName;
				}
			}

			else if (selected == 2)
			{
				if (GUILayout.Button(string.IsNullOrEmpty(data.nfo[2]) ? "-select-" : data.nfo[2]))
				{
					selectingItem = true; 
				}
			}
		}
		
		private void ShowSelectItem(plyDataObject data)
		{
			GUILayout.Label("Select Item");
			if (GUILayout.Button(GC_BACK, plyEdGUI.ButtonStyle))
			{
				selectingItem = false;
				return;
			}

			foreach (Item it in itemsAsset.items)
			{
				if (GUILayout.Button(it.ToString()))
				{
					data.nfo[1] = it.prefabId.ToString();
					data.nfo[2] = it.ToString(); 
					selectingItem = false;
					return;
				}
			}
		}

		// ============================================================================================================
	}
}