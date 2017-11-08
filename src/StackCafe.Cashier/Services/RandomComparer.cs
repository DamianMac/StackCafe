using System;
using System.Collections.Generic;

namespace StackCafe.Cashier.Services
{
    internal class RandomComparer : IComparer<string>
    {
        private static Random random = new Random();
        public int Compare(string x, string y)
        {
            return random.Next(-1, 1);
        }
    }
}