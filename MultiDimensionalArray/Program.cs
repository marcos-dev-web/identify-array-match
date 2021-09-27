using System;
using System.Linq;

namespace MultiDimensionalArray
{
    class Program
    {
        static void Main(string[] args)
        {

          int [,] array = new int[,] {
            { 0, 1, 0 },
            { 0, 1, 1 },
            { 1, 1, 0 }
          };

          VerifyMatch Match = new VerifyMatch(array);

          Match.ShowTable();

          Match.CheckMatch();
        }
    }
}
