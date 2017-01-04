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
	public class DiaQuestCondFieldData : IBlockValidate
	{
		public int idx = -1; // index

		public override string ToString()
		{
			return (idx < 0 ? "-invalid-" : ("#"+idx.ToString()));
		}

		public DiaQuestCondFieldData Copy()
		{
			DiaQuestCondFieldData o = new DiaQuestCondFieldData();
			o.idx = this.idx;
			return o;
		}

		public bool IsValid()
		{
			return (idx >= 0);
		}

		// ============================================================================================================
	}
}