// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using plyCommon;
using plyGame;

namespace DiaQ
{				 
	public class plyRPGDiaQRewardHandler : MonoBehaviour, plyDataProviderInterface
	{

		/// <summary> Called when general callback is made into implementer. 
		/// Use case will depend on what system makes the call.
		/// Passed the nfo[] array as set up in plyDataObject. </summary>
		public void DataProvider_Callback(string[] nfo)
		{
			// nfo[0] = 0:Currency, 1:Attribute, 2:Item
			// nfo[1] = the identifier of the attribute or item (not used with currency selected)
			// nfo[2] = cached name of selected attribute or item
			// nfo[3] = value/ amount (as set in reward editor)

			int val = 0;
			int.TryParse(nfo[3], out val);
			if (val <= 0)
			{
				Debug.LogError("The Reward Value is <= 0. Nothing was updated.");
				return;
			}

			if (nfo[0] == "0")
			{
				ItemBag bag = Player.Instance.actor.GetComponent<ItemBag>();
				if (bag != null) bag.AddCurrency(val);
				else Debug.LogError("The Player has no ItemBag component. Can't add currency.");
			}

			else if (nfo[0] == "1")
			{
				ActorAttribute att = Player.Instance.actor.actorClass.GetAttribute(new UniqueID(nfo[1]));
				if (att != null) att.ChangeBaseValueBy(val);// att.SetValue(val);
				else Debug.LogError("Could not find the Attribute. make sure you linked the Attribute in the Player's Actor Class.");
			}

			else if (nfo[0] == "2")
			{
				ItemBag bag = Player.Instance.actor.GetComponent<ItemBag>();
				if (bag != null)
				{
					Item it = ItemsAsset.Instance.GetDefinition(new UniqueID(nfo[1]));
					if (it != null)
					{
						for (int i = 0; i < val; i++)
						{
							if (false == bag.AddItemToBag(it))
							{
								Debug.LogWarning("Could not add [" + it.def.screenName + "] to bag. It might be full.");
							}
						}
					}
					else Debug.LogError("The Item to give the player could not be found. Did you delete it from the Item definitions?");
				}
				else Debug.LogError("The Player has no ItemBag component. Can't add items.");
			}

		}

		/// <summary> Override to provide the data. Passed the nfo[]
		/// array as set up in plyDataObject. </summary>
		public object DataProvider_GetValue(string[] nfo)
		{
			// not used in this context
			return null;
		}

		/// <summary> Override to set the data. Passed the nfo[] array
		/// as set up in plyDataObject and a value to set. </summary>
		public void DataProvider_SetValue(string[] nfo, object value)
		{
			// not used in this context
		}

		// ============================================================================================================
	}
}
