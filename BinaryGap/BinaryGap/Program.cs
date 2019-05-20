using System;
using System.Diagnostics;
using System.Linq;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {

            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            int[] numbers = { 1,2,147,483,647,1111,5555,666666,3453,35,35,234,234,23564,235,234,124,1241234,1241412,124124};
            //int[] numbers = {1111};
            string[] binaryArrayNumbers = new string[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                binaryArrayNumbers[i] = ConvertToBinary(numbers[i]);
            }

            var res = BinaryGap(binaryArrayNumbers);
            
            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"GC Gen #2  :  { GC.CollectionCount(2)} - before2 ");
            Console.WriteLine($"GC Gen #1  :  { GC.CollectionCount(1)} - before1 ");
            Console.WriteLine($"GC Gen #0  :  { GC.CollectionCount(0)} - before0 ");

            Console.WriteLine(res);
        }


        static string ConvertToBinary(long number)
        {
            var acumula = string.Empty;
            long aux = 0;
            while (number > 0)
            {
                
                acumula += number % 2;
                number = number / 2;
                
               
            }

            var reverted = Revert(acumula);

            
            
            return reverted;
        }

        static int BinaryGap(params string[] binaryNumbers)
        {
            int lenght = 0;
            int greatestLenght = 0;

            string formed = string.Empty;
            
            for (int i = 0; i < binaryNumbers.Length; i++)
            {

                for (int j = 0; j < binaryNumbers[i].Length; j++)
                {

                    if (binaryNumbers[i][j] == '1')
                    {
                        formed += binaryNumbers[i][j];

                        greatestLenght = lenght > greatestLenght ? lenght : greatestLenght;
                        lenght = 0;

                    }
                    else if (binaryNumbers[i][j] == '0'
                             && formed != string.Empty
                             && binaryNumbers[i]
                                 .Substring(j, binaryNumbers[i].Length - j)
                                 .Contains('1')
                    ){
                        lenght += 1;
                    }
                    
                }
                
            }
            
            return greatestLenght;
        }

        public static string Revert(string word)
        {
            var aux = string.Empty;

            for (int i = word.Length-1; i >= 0; i--)
            {
                aux += word[i];
            }

            return aux;
        }
    }
}