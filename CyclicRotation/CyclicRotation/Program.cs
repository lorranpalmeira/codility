using System;
using System.Diagnostics;

namespace CyclicRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] rotate = {};
            //int[] rotate = {1, 2, 3, 4};
            //int[] rotate = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            //int[] rotate = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

            var elementos = 4;
            int[] rotate = new int[elementos];
            for (int i = 0; i < elementos; i++)
            {
                rotate[i] = i;
            }

            var numberOfTimes = 1_000_000_000;
            
            
            Console.WriteLine("==============Block===========================");
            CyclicBlockArray(rotate,numberOfTimes);

            Console.WriteLine("=================Array Copy==================");
            CyclicCopyArray(rotate, numberOfTimes);

            Console.WriteLine("==============================================");
            CyclicRotationArray(rotate, numberOfTimes);


            
            
            
//            Console.WriteLine("==============Block===========================");
//            foreach (var item in  CyclicBlockArray(rotate,numberOfTimes))
//            {
//                Console.WriteLine(item);
//            }
//            Console.WriteLine("=================Array Copy==================");
//
//            foreach (var item in CyclicCopyArray(rotate,numberOfTimes))
//            {
//                Console.WriteLine(item);
//            }
//
//            Console.WriteLine("==============================================");
//            
//            foreach (var item in CyclicRotationArray(rotate,numberOfTimes))
//            {
//                Console.WriteLine(item);
//            }
        }


        static int[] CyclicCopyArray(int[] rotationArray, int numberOfTime)
        {
            var gc0 = GC.CollectionCount(0);
            var gc1 = GC.CollectionCount(1);
            var gc2 = GC.CollectionCount(2);
            var sw = new Stopwatch();
            sw.Start();


            int[] aux = new int[rotationArray.Length];


            for (int i = 0; i < numberOfTime; i++)
            {
                var lastPos = rotationArray[rotationArray.Length - 1];
                Array.Copy(rotationArray, 0, aux, 1, rotationArray.Length - 1);
                aux[0] = lastPos;
                Array.Copy(aux, rotationArray, 0);
            }

            sw.Stop();
            Console.WriteLine($"Time spent: {sw.Elapsed}");

            Console.WriteLine($"GC0 -> {gc0}");
            Console.WriteLine($"GC1 -> {gc1}");
            Console.WriteLine($"GC2 -> {gc2}");


            return rotationArray;
        }

        static T[] CyclicRotationArray<T>(T[] rotationArray, int numberOfTime)
        {
            var gc0 = GC.CollectionCount(0);
            var gc1 = GC.CollectionCount(1);
            var gc2 = GC.CollectionCount(2);
            var sw = new Stopwatch();
            sw.Start();

            if (rotationArray.Length == 0)
            {
                return rotationArray;
            }

            for (int j = 0; j < numberOfTime; j++)
            {
                T[] rotatePlus = new T[rotationArray.Length];
                var lastPos = rotationArray[rotationArray.Length - 1];
                for (int i = 1; i < rotationArray.Length; i++)
                {
                    rotatePlus[i] = rotationArray[i - 1];
                }

                rotatePlus[0] = lastPos;
                rotationArray = rotatePlus;
            }


            sw.Stop();
            Console.WriteLine($"Time spent: {sw.Elapsed}");

            Console.WriteLine($"GC0 -> {gc0}");
            Console.WriteLine($"GC1 -> {gc1}");
            Console.WriteLine($"GC2 -> {gc2}");

            return rotationArray;
        }


        static int[] CyclicBlockArray(int[] rotationArray, int numberOfTime)
        {
            var gc0 = GC.CollectionCount(0);
            var gc1 = GC.CollectionCount(1);
            var gc2 = GC.CollectionCount(2);
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            
            int[] aux = new int[rotationArray.Length];
            
            int size = sizeof(int);
            int length = rotationArray.Length * size; 
           

            for (int i = 0; i < numberOfTime; i++)
            {
                var lastPos = rotationArray[rotationArray.Length - 1];
                Array.Copy(rotationArray, 0, aux, 1, rotationArray.Length - 1);
                aux[0] = lastPos;
                Buffer.BlockCopy(aux, 0, rotationArray, 0, length);
                
            }
                


            sw.Stop();
            //Console.WriteLine("Buffer.BlockCopy: {0:N0} ticks",
            //  sw.ElapsedTicks);
            Console.WriteLine($"Time spent: {sw.Elapsed}");

            Console.WriteLine($"GC0 -> {gc0}");
            Console.WriteLine($"GC1 -> {gc1}");
            Console.WriteLine($"GC2 -> {gc2}");


            return rotationArray;
        }
    }
}