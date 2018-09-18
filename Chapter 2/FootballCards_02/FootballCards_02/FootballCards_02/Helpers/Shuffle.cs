using System;
using System.Collections.Generic;
using FootballCards_02.Model;

namespace FootballCards_02.Helpers
{
	public static class CardShuffle
	{
		static Random rng = new Random();
		static int Shuffles = 0;

		public static List<Cards> Shuffle(this List<Cards> list, int shuffles)
		{
			if (Shuffles < shuffles)
			{
				int n = list.Count;
				while (n > 1)
				{
					n--;
					int k = rng.Next(n + 1);
					var value = list[k];
					list[k] = list[n];
					list[n] = value;
				}
				Shuffles++;
				Shuffle(list, shuffles);
			}
			Shuffles = 0;
			return list;
		}
	}
}

