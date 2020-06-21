using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Utils
{
	/// <summary>
	/// For all of your Random needs!
	/// </summary>
	public class Randomness
	{
		public static Random Randomizer = new Random((int) DateTime.Now.Ticks);

		public static string RandomString(int size)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < size; i++)
			{
				var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Randomizer.NextDouble() + 65)));
				builder.Append(ch);
			}
			return builder.ToString();
		}
    }
}
