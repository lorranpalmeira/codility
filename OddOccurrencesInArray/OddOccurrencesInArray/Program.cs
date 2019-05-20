using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OddOccurrencesInArray
{
    class Program
    {


        static void Main(string[] args)
        {
            //int[] numberArray = { 2,2,3,3,4,5,4,8,8,8,15,15,7,6,6,7,5 };
            int[] A = {9, 3, 9, 5, 3, 9, 7, 7, 9};

            int[] B = {6, 8, 3, 9, 8, 2};

            var sw = new Stopwatch();
            sw.Start();

            var gc0 = GC.CollectionCount(0);
            var gc1 = GC.CollectionCount(1);
            var gc2 = GC.CollectionCount(2);

            //var result = checkPaired(numberArray);


            //////// BITWISE //////////////////////////////////
            // write your code in Java SE 8
//            int elem = 0;
//
//            for (int i = 0; i < A.Length; i++)
//            {
//                //elem ^= A[i];
//                elem = elem ^ A[i];
//
//            }

            /////////////////  BIT //////////////////
             
            printRepeatingEven(B, B.Length);
            
            
           
                //////////////////////////////

                sw.Stop();

                //Console.WriteLine(elem);


                Console.WriteLine($"Time spent : {sw.Elapsed}");
                Console.WriteLine($"GC 0 : {gc0}");
                Console.WriteLine($"GC 1 : {gc1}");
                Console.WriteLine($"GC 2 : {gc2}");


            }
        
        static void printRepeatingEven(int[] arr, int n) 
        { 
            long _xor = 0L; 
            long pos; 
  
            // do for each element of array  
            for (int i = 0; i < n; ++i)  
            { 
                // right pos 1 by value of  
                // current element  
                pos = 1 << arr[i]; 
  
                // Toggle the bit everytime  
                // element gets repeated  
                _xor ^= pos; 
            } 
  
            // Traverse array again and use _xor  
            // to find even occuring elements  
            for (int i = 0; i < n; ++i) 
            { 
                // right shift 1 by value of  
                // current element  
                pos = 1 << arr[i]; 
  
                // Each 0 in _xor represents 
                // an even occurrence  
                if (!((pos & _xor) != 0))  
                { 
                    // print the even occurring numbers  
                    Console.WriteLine(arr[i] + " "); 
  
                    // set bit as 1 to avoid  
                    // printing duplicates  
                    _xor ^= pos; 
                } 
            } 
        } 

            static int checkPaired(int[] numberArray)
            {

                Array.Sort(numberArray);

                for (int i = 0; i < numberArray.Length; i = +2)
                {
                    if (i + 1 == numberArray.Length)
                        return numberArray[i];
                    if (numberArray[i] != numberArray[i + 1])
                        return numberArray[i];
                }


                return 0;

//            int[] newNumberArray = new int[numberArray.Length];
//
//            for (int i = 0; i < numberArray.Length; i++)
//            {
//               
//                if(newNumberArray.Any(x => x == numberArray[i]))
//                {
//                    var saveValue = numberArray[i];
//                    numberArray[i] = -1;
//                    var found = Array.LastIndexOf(numberArray, saveValue);
//                    
//                    numberArray[found] = -1;
//                }
//                else //if(numberArray[i]>0)
//                {
//                    newNumberArray[i] = numberArray[i];
//                }
//            }
//            var numberUnPaired = numberArray.FirstOrDefault(x => x > -1);
//
//            return numberUnPaired;

            
        }


    }
}