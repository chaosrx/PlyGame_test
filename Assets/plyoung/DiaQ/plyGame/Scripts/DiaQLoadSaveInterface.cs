// -= DiaQ =-
// www.plyoung.com
// Copyright (c) Leslie Young
// ====================================================================================================================

using UnityEngine;
using System.Collections;
using plyCommon;
using plyGame;

namespace DiaQ
{
	/// <summary>
	/// Provides the link between DiaQ and the plygame LoadSave System
	/// </summary>
	public class DiaQLoadSaveInterface : MonoBehaviour
	{
		protected void Start()
		{
			GameGlobal.RegisterLoadSaveListener(SaveData, LoadData, DeleteData, null);
		}

		private void SaveData(object sender, object[] args)
		{
			string data = DiaQEngine.Instance.GetSaveData();
			//Debug.Log("DIAQ SAVE: " + data);
			GameGlobal.SetStringKey("DIAQ", data);
		}

		private void LoadData(object sender, object[] args)
		{
			string data = GameGlobal.GetStringKey("DIAQ", null);
			//Debug.Log("DIAQ LOAD: " + data);
			DiaQEngine.Instance.RestoreFromSaveData(data);
		}

		private void DeleteData(object sender, object[] args)
		{
			GameGlobal.DeleteKey("DIAQ");
		}

	}
}