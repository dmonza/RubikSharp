using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonzaRubikLib
{
   public class Move
   {
      public int Axis=0;
      public int Level=0;
      public int Turns=0;

      public Move(int a, int l, int t) {
         this.Axis = a;
         this.Level = l;
         this.Turns = t;
      }
      public override string ToString()
      {
         string r = "";
         if (this.Axis == 0)
            r = "X";
         else if (this.Axis == 1)
            r = "Y";
         else
            r = "Z";

         r += this.Level.ToString().Trim() + ".";
         if (this.Turns == 3)
            r += "-1";
         else
            r += this.Turns.ToString();

         return r;
      }
   }
}
