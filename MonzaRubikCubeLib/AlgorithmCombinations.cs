using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MonzaRubikLib
{
   public class AlgorithmCombinations : AbstractAlgorithm
   {
      private int maxDeep = 4; // Axis change max levels

      public int solved = 0;
      
      public AlgorithmCombinations() : base(){}

      public int MaxDeep { get { return this.maxDeep; } }

      public override string ToString()
      {
         return "Combinations";
      }

      // Procedimiento de rotación para tener control de movimientos
      protected override void init(RubikCube template)
      {
         base.init(template);
         this.solved = 0;         
      }

      public override void Resolve(RubikCube from, RubikCube to) // From: Generalmente mastercube To: Obtener un cubo que contemple el modelo recibido
      {
         this.init(to);
         
         if (!to.Equals(from))
         {
            ProcessParms parms = null;

            // Load all axis
            parms = new ProcessParms( from, 0, 9, new ArrayList());
            fillCubeAux( parms);
         }
         else
            this.cubeMatch = from.Clone();
      }

      private void fillCubeAux(ProcessParms parms)
      {
         // Axis deep
         parms.Deep += 1;

         if ( parms.Deep <= maxDeep)
         {
            // Axis changes
            for (int axis = 0; axis < 3; axis++)
            {
               if (axis != parms.CurrentAxis || parms.CurrentAxis > 2) // The last is for axis = 9
               {
                  ProcessParms p2 = new ProcessParms( parms.WorkingCube, parms.Deep, axis, parms.Moves);

                  if (parms.Thread == -1) {
                     p2.Thread = this.getFreeThread();
                     this.startProcess( p2.Thread, () => processAxis(p2) ) ;
                  }
                  else
                  {
                     p2.Thread = parms.Thread;
                     processAxis(p2);
                  }

                  if (this.cubeMatch != null)
                  {
                     if (this.Template.Equals(this.cubeMatch) || this.IsCanceled)
                        return;
                  }

               } // Axis

            }
         }

         parms.Deep -= 1;
      }
      
      private void processAxis(Object o)
      {
         ProcessParms parms = (ProcessParms)o;

         // Se procesan todas las conbinaciones de movimientos para un nivel
         for (int level1 = 0; level1 <= 3; level1++)
         {
            if (this.Rotate( parms, parms.CurrentAxis, 1))
               return;

            for (int level2 = 0; level2 <= 3; level2++)
               {
                  if (this.Rotate(parms, parms.CurrentAxis, 2))
                     return;

                  for (int level3 = 0; level3 <= 3; level3++)
                  {
                     if (this.Rotate( parms, parms.CurrentAxis, 3))
                        return;

                     // Don't you fillcubeaux on the original cube
                     if (!(level1 == 3 && level2 == 3 && level3 == 3))
                     {
                           fillCubeAux( parms );
                     }
                     
                     if (this.cubeMatch != null || this.IsCanceled)
                        return;

                  } // Level3
                 
               } // Level2 
              
            } // Level1
      }
   }
}
