using System.Collections.Generic;

namespace CustomComparator
{
    public class EvenOrOddComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a % 2 == 0 && b % 2 != 0)
            {
                return -1;
            }
            else if (b % 2 == 0 && a % 2 != 0)
            {
                return 1;
            }
            else
            {
                if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}