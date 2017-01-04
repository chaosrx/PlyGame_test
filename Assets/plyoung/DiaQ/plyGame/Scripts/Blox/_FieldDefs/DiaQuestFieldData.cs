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
	public class DiaQuestFieldData : IBlockValidate
	{
		public int id = -1; // unique id
		public string cachedName = "";

		public override string ToString()
		{
			return string.IsNullOrEmpty(cachedName) ? "-invalid-" : cachedName;
		}

		public DiaQuestFieldData Copy()
		{
			DiaQuestFieldData o = new DiaQuestFieldData();
			o.id = this.id;
			o.cachedName = this.cachedName;
			return o;
		}

		public bool IsValid()
		{
			return (id >= 0);
		}

		// ============================================================================================================
	}
}