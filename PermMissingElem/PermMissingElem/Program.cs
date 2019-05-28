using System;
using System.Collections.Generic;



namespace PermMissingElem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = { 1};
            //int[] A = {1, 3, 4, 5,9,7,8,6};
            int[] A = {1, 2,3, 4, 5};

            Console.WriteLine("Result: " + Solution(A));
        }

        static int Solution(int[] A)
        {
            if (A.Length == 0)
                return 1;

            var ordered = new SortedSet<int>();

            for (int i = 0; i < A.Length; i++)
                ordered.Add(A[i]);


            var last = 0;
            var finalGap = false;

            foreach (var item in ordered)
            {
                if (last + 1 == item)
                {
                    finalGap = true;
                    last = item;
                    continue;
                }

                return last + 1;
            }

            if (finalGap)
                return last + 1;


            return 2;
        }
    }
}
