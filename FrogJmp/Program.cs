using System;
using System.Diagnostics;

namespace FrogJmp
{
    class Program
    {
        static void Main(string[] args)
        {
            int X = 10;
            int Y = 85;
            int D = 30;
            Console.WriteLine(FrogJmp(X,Y,D));
        }

        static int FrogJmp(int X, int Y, int D) =>  ((Y - X) + D - 1)/D;
        
        
        
        
   
    }
}