using System;
using System.Collections.Generic;
using FootballCards_01.Model;

namespace FootballCards_01.Helpers
{
    public static class CardShuffle
    {
        static Random rng = new Random();
        static int NumberShuffles = 0;

        public static List<Cards> Shuffle(this List<Cards> list, int shuffles)
        {
            if (NumberShuffles < shuffles)
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
                NumberShuffles++;
                Shuffle(list, shuffles);
            }
            return list;
        }
    }
}

