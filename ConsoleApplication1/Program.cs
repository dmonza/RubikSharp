using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonzaRubikLib;

namespace ConsoleApplication1
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("CuboA: " + args[0]);
         Console.WriteLine("CuboB: " + args[1]);

         RubikCube cubeA = new RubikCube();
         //cubeA.fromString("0|0|0|0|0|0|1|5|5|0|0|6|5|5|0|0|1|1|6|0|0|0|0|0|0|0|5|3|2|0|4|0|0|0|1|4|0|0|0|1|6|0|0|0|4|0|2|2|1|0|0|1|4|2|0|6|0|0|0|3|1|0|0|0|3|6|0|0|0|5|0|2|2|2|0|0|4|3|6|0|3|0|0|0|4|4|0|0|0|1|6|0|0|0|5|0|2|3|2|0|0|0|0|0|0|0|5|4|3|0|0|5|6|4|0|0|3|6|3|0|0|0|0|0|0|");
         cubeA.fromString(args[0]);

         RubikCube cubeB = new RubikCube();
         cubeB.fromString(args[1]);
         //cubeB.fromString("0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|1|1|1|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|6|0|0|0|5|0|2|2|2|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|6|0|0|0|5|0|2|2|2|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|6|0|0|0|5|0|2|0|2|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|3|0|3|0|0|0|0|0|0|");

         AlgorithmCombinations alg = new AlgorithmCombinations(4);
         /*
          * RubikCube result = alg.resolveSingle(cubeA, cubeB, 9);

         if (result != null)
            Console.WriteLine("OK!");
         else
            Console.WriteLine("None");

         */
      }
   }
}
