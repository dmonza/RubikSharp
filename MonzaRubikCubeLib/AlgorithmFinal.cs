using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MonzaRubikLib
{
   public class AlgorithmFinal : AbstractAlgorithm
   {      
      public AlgorithmFinal() : base()
      {
      }

      public override string ToString()
      {
         return "Final";
      }

      protected override void init()
      {
         base.init();
      }

      public override void Resolve(RubikCube from, RubikCube to) // From: Generalmente mastercube To: Obtener un cubo que contemple el modelo recibido
      {
         this.init();

         RubikCube WorkingCube = from.Clone();

         if (!to.Equals(from))
         {

            this.startProcess(() => _resolve(from,  to));

         }
         else
            this.cubeMatch = from.Clone();
      }

      private void _resolve(RubikCube from, RubikCube to)
      { 
          RubikCube working = from.Clone();
          RubikCube template = new RubikCube();
          
          template.clear();
          template.ToMatrix()[2,4,2] = to.ToMatrix()[2,4,2];
          template.ToMatrix()[2,4,3] = to.ToMatrix()[2,4,3];
          template.ToMatrix()[2,3,4] = to.ToMatrix()[2,3,4];

          working = this._resolveCross(working, template.Clone());
          if (working != null)
          {
             template.ToMatrix()[1, 4, 2] = to.ToMatrix()[1, 4, 2];
             template.ToMatrix()[0, 3, 2] = to.ToMatrix()[0, 3, 2];

             working = this._resolveCross(working, template.Clone());
             if (working != null) {
                template.ToMatrix()[2, 4, 1] = to.ToMatrix()[2, 4, 1];
                template.ToMatrix()[2, 3, 0] = to.ToMatrix()[2, 3, 0];

                working = this._resolveCross(working, template.Clone());
                if (working != null) {
                   template.ToMatrix()[3, 4, 2] = to.ToMatrix()[3, 4, 2];
                   template.ToMatrix()[4, 3, 2] = to.ToMatrix()[4, 3, 2];

                   working = this._resolveCross(working, template.Clone());
                   if (working != null){
                      template.ToMatrix()[2, 2, 4] = to.ToMatrix()[2, 2, 4];
                      working = this._resolveCross(working, template.Clone());

                      if (working !=null){
                         template.ToMatrix()[0, 2, 2] = to.ToMatrix()[0, 2, 2];
                         working = this._resolveCross(working, template.Clone());

                         if (working !=null){
                              template.ToMatrix()[2, 2, 0] = to.ToMatrix()[2, 2, 0];
                              working = this._resolveCross(working, template.Clone());
                              if (working !=null){
                                 template.ToMatrix()[4, 2, 2] = to.ToMatrix()[4, 2, 2];
                                 working = this._resolveCross(working, template.Clone());
                              }
                         }
                      }
                   }
                }
             }
          }
          this.cubeMatch = working;
      }

      private RubikCube _resolveCross(RubikCube from, RubikCube to){
         if (this.IsCanceled)
            return null;

         //AbstractAlgorithm ac = new AlgorithmRandom(500000, 5);
         AbstractAlgorithm ac = new AlgorithmCombinations(4);

         ac.Resolve(from, to);
         while (!ac.IsCompleted) {
            this.status = ac.Status();
            if (this.IsCanceled)
               ac.Cancel();
            System.Threading.Thread.Sleep(200);
         }
         if (ac.cubeMatch != null)
            this.addMoves(ac.winnerMoves);

         this.cubeStat = ac.cubeMatch;
         return ac.cubeMatch;
      }

      private void addMoves(ArrayList _m) {
         foreach (Move m in _m) {
            this.winnerMoves.Add(m);
         }
      }
      public string status;
      public override string Status()
      {
         return this.status;
      }
   }
}
