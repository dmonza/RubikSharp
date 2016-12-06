using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MonzaRubikLib
{
   public abstract class AbstractAlgorithm
   {
      protected RubikCube Template;

      // Multithread attributes
      private int maxthreads = 25;

      private int threads;
      private Task[] list;
      private bool isCancel;

      // protected int operations = 0;
      protected int[] operationsByThread;


      // Solution and winner
      public ArrayList winnerMoves;
      public int winnerThread = -1;
      public RubikCube cubeMatch;
      public RubikCube cubeStat;

      public AbstractAlgorithm() { 
      }


      public int Operations { get { 
         int operations=0;
         for (int i = 0; i < threads; i++) { 
            operations+=operationsByThread[i];
         }
         return operations;
      } }

      public abstract void Resolve(RubikCube from, RubikCube to);

      public bool IsCanceled { get { return this.isCancel; } }

      public void Cancel()
      {
         this.isCancel = true;
      }

      public bool IsCompleted{
         get {
            if (list == null)
               return true;

            lock (this.list){               

               for (int i = 0; i < this.maxthreads; i++)
               {
                  if (list[i] != null)
                  {
                     if (!list[i].IsCompleted)
                        return false;
                     else
                     {
                        // Si el thread está completo, lo libero
                        list[i] = null;
                        this.threads--;
                     }

                  }
               }
            }
            return true;
         }
      }

      protected virtual void init(RubikCube template) {
         Console.WriteLine("Abrastract:init()");

         this.Template = template;

         list = new Task[maxthreads];

         this.threads = 0;
         this.operationsByThread = new int[maxthreads];

         this.winnerMoves = new ArrayList();
         //this.cubeTemplate = to.Clone();
         this.cubeMatch = null;
         this.cubeStat = new RubikCube();
         this.isCancel = false;
      }

      protected int getFreeThread() {
         // threads comienza en 0
         if (this.threads<this.maxthreads)
            return this.threads++;
         else
            return -1;
         /*
         lock (this.list)
         {
            if (this.threads < this.maxthreads)
            {
               for (int i = 0; i < this.maxthreads; i++)
               {
                  if (this.list[i] == null)
                  {
                     //lock (this.threads)
                     //{
                        this.threads++;
                     //}                        
                     return i;
                  }

               }
            }
         }
         return -1;
         */
      }

      protected void startProcess(int t, Action action)
      {
         lock (this.list)
         {
            this.list[t] = new Task(action);
            // System.Threading.Thread.Sleep(100); // Some delay
            this.list[t].Start();
         }
      }
      
      /// <summary>
      /// Do a cube rotation and return true if the process was cancelled or exists a match winner
      /// </summary>
      /// <param name="param1">Some Parameter.</param>
      /// <returns>What this method returns.</returns>
      protected bool Rotate(ProcessParms parms, int axis, int level)
      {
         if (this.cubeMatch != null || this.IsCanceled)
            return true;

         // -----------------------------------------
         // Add movement to list
         // -----------------------------------------
         bool rotate = true;

         Move m = null;
         bool add = false;
         if (parms.Moves.Count == 0)
            add = true;
         else
         {
            m = (Move)parms.Moves[parms.Moves.Count - 1];
            if (m.Axis == axis && m.Level == level)
            {
               // If last movment is the 3rd, we remove it because one more is useless
               if (m.Turns >= 3)
               {
                  parms.Moves.RemoveAt(parms.Moves.Count - 1);
                  rotate = false;
               }
               else
                  m.Turns++; // Same movement
            }
            else
               add = true;
         }

         if (add)
         {
            m = new Move( axis, level, 1);
            parms.Moves.Add(m);
         }
         // ---------------------------------

         // Chequeo si se eliminó el movimiento. En ese caso no es necesario chequear
         // Se rota pero no se compara, esto es para que regrese a la posición anterior
         //if (parms.Thread == 2)
         //   Console.WriteLine("Axis: {0} Level: {1} Deep: {2}", axis, level, parms.Deep);

         parms.WorkingCube.rotateFace(axis, level);
         if (rotate)
         {
               lock (this.winnerMoves)
               {
                  // Siempre se chequea desde el template para optimizar el cache de viewPoints
                  if (this.Template.Equals(parms.WorkingCube))
                  {
                     this.cubeMatch = parms.WorkingCube.Clone();
                     this.winnerThread = parms.Thread;
                     this.winnerMoves = parms.Moves;
                  }

                  lock (this.operationsByThread)
                  {
                     this.operationsByThread[parms.Thread]++;
                  }
                  if (this.Operations % 5000 == 0)
                     this.raiseUpdateForm(parms.WorkingCube);
               }
         }
         if (this.cubeMatch != null)
            return true;
         else
            return false;
      }

      // Events
      protected void raiseUpdateForm(RubikCube cube)
      {
         lock (cubeStat)
         {
            cubeStat.fromMatrix(cube.ToMatrix());
         }
      }

      public virtual string Status()
      {
         string s = "";
         for (int i = 0; i < threads; i++) { 
            s+= string.Format("T{0}:{1};", i, this.operationsByThread[i]);
         }
         return s;
      }
   }
}
