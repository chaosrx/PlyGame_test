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
	public class plyGraphFieldData : IBlockValidate
	{
		public string id = ""; // graph unique id
		public string cachedName = "";

		public override string ToString()
		{
			return string.IsNullOrEmpty(cachedName) ? "-invalid-" : cachedName;
		}

		public plyGraphFieldData Copy()
		{
			plyGraphFieldData o = new plyGraphFieldData();
			o.id = this.id;
			o.cachedName = this.cachedName;
			return o;
		}

		public bool IsValid()
		{
			return (false == string.IsNullOrEmpty(id));
		}

		// ============================================================================================================
	}
}