using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MonzaRubikLib
{
   public class ProcessParms
   {
      public RubikCube WorkingCube;
      public int Deep;
      public int CurrentAxis;
      public int Thread;
      public int Operations;
      public ArrayList Moves;

      public ProcessParms(  RubikCube workingCube, int deep, int currentAxis, ArrayList Moves)
      {
         this.Thread = -1;
         this.WorkingCube = workingCube.Clone();
         this.Deep = deep;
         this.CurrentAxis=currentAxis;
         this.Operations = 0;
         this.Moves = (ArrayList)Moves.Clone();

         // Console.WriteLine("Thread: {0} Axis: {1}", this.Thread.ToString(), this.CurrentAxis.ToString());
      }
   }
}
