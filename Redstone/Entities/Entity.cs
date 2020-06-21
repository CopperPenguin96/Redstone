using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Entities
{
	public class Entity
	{
		public static int LastID = -1;

		public static int GetNextID()
		{
			return LastID += 1;
		}

		private int _id;

		public int ID
		{
			get
			{
				if (_id == -1) _id = GetNextID();

				return _id;
			}
		}
	}


}
