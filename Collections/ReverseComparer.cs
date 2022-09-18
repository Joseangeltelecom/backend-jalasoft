﻿namespace Collections
{
    internal class ReverseComparer: IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -x.CompareTo(y);
        }
    }
}
