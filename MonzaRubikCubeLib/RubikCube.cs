using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;

namespace MonzaRubikLib
{
   /*
    *        case 1: return Color.Blue;
             case 2: return Color.Yellow;
             case 3: return Color.Green;
             case 4: return Color.White;
             case 5: return Color.Red;
             case 6: return Color.Orange;
    * */
    public enum RubikColors : int { Blue = 1, Yellow = 2, Green = 3, White = 4, Red = 5, Orange = 6 };
    
    public class RubikCube
    {
       public static int[,] sidesshapes; // solo usado para colors=false - debug
       private static int[,] validPositions=new int[54,3];

       private int[, ,] cube;

       // Master Cube
       private int[, ,] masterCube;

       public RubikCube() {
           this.masterCube = getMasterCube();
           this.clear();
        }

       private static int[, ,] getMasterCube() {
           int[, ,] ncube = new int[5, 5, 5];
           int shape = 0;

           sidesshapes = new int[6, 10];

           for (int x = 0; x < 5; x++)
           {
              for (int y = 0; y < 5; y++)
              {
                 for (int z = 0; z < 5; z++)
                 {

                    if (
                         (z == 4 && x > 0 && x < 4 && y > 0 && y < 4) || // Cara I
                         (z == 0 && x > 0 && x < 4 && y > 0 && y < 4) || // Cara III
                         (x == 4 && z > 0 && z < 4 && y > 0 && y < 4) || // Cara I
                         (x == 0 && z > 0 && z < 4 && y > 0 && y < 4) || // Cara III
                         (y == 4 && x > 0 && x < 4 && z > 0 && z < 4) || // Cara I
                         (y == 0 && x > 0 && x < 4 && z > 0 && z < 4) // Cara III
                       )
                    {

                       // Identifico los números correspondientes a cada cara
                       int face = 0;
                       if (z == 4) // Cara I
                          face = 1;
                       else if (y == 4) // Cara II
                          face = 2;
                       else if (z == 0) // Cara III
                          face = 3;
                       else if (y == 0)
                          face = 4;
                       if (x == 0)
                          face = 5;
                       else if (x == 4)
                          face = 6;

                       // Optimizo las posiciones válidas del cubo para las comparaciones.
                       validPositions[shape, 0] = x;
                       validPositions[shape, 1] = y;
                       validPositions[shape, 2] = z;
                       shape++;

                       //if (_colors)
                       //{
                          ncube[x, y, z] = face;
                       //}
                       //else
                       //{
                       //   sidesshapes[0, (sidesshapes[face - 1, 0]++) + 1] = shape;
                       //   ncube[x, y, z] = shape++;
                       //}
                    }
                    else
                       ncube[x, y, z] = 0;
                 }
              }
           }
           return ncube;
        }

       private int[, ,] MasterCube
        {
           get
           {
              return this.masterCube;
           }
        }
        
       // -------------------

       public int[, ,] ToMatrix() {
           return this.cube;
        }

       public void fromString(string s) {
          int pos = 0;
          string[] v = s.Split('|');

          for (int x = 0; x < 5; x++)
          {
             for (int y = 0; y < 5; y++)
             {
                for (int z = 0; z < 5; z++)
                {
                   this.ToMatrix()[x,y,z] = Convert.ToInt32(v[pos++]);
                }
             }
          }
       }
       public override string ToString()
       {
          string r = "";

                       // Se realiza la comparación. Aunte una incompatibilidad, se cancela.
          for (int x = 0; x < 5 ; x++)
          {
             for (int y = 0; y < 5 ; y++)
             {
                for (int z = 0; z < 5 ; z++)
                {
                   /*
                   switch (this.ToMatrix()[x, y, z])
                   {
                      case (int)RubikColors.Yellow:
                         r += "YE";
                         break;
                      case (int)RubikColors.Blue:
                         r += "BL";
                         break;
                      case (int)RubikColors.Green:
                         r += "GR";
                         break;
                      case (int)RubikColors.Orange:
                         r += "OR";
                         break;
                      case (int)RubikColors.Red:
                         r += "RE";
                         break;
                      case (int)RubikColors.White:
                         r += "WH";
                         break;

                      default:
                         r += "--";
                         break;
                   }*/
                   r+=this.ToMatrix()[x, y, z]+"|";
                      
                }
             }
          }
          
          return r;
       }
       
       public void fromMatrix(int[,,] cubein) {
           this.cube = (int[,,])cubein.Clone();
       }

        public void clear() {
           this.cube = new int[5, 5, 5];
        }
        
        public void setMasterCube() {
           this.cube = getMasterCube();
        }
        public void setRandom() {
           this.setMasterCube();
           Random r = new Random();
           int moves = r.Next(3,4);
           for (int i = 1; i <= moves; i++) {
              this.rotateFace( r.Next(0,2), r.Next(1,3));
           }
        }

        public static int[,] get2dFace(int[,,] cubex, int axis, int deep) {
           int[,] mat = new int[5, 5];
           for (int x = 0; x < 5; x++)
           {
              for (int y = 0; y < 5; y++)
              {
                 int[] coords = get3dCoords(axis, deep, x, y);
                 mat[x, y] = cubex[coords[0], coords[1], coords[2]];
              }
           }

           return mat;
        }
        
        private static int[] get3dCoords(int axis, int deep, int xi , int yi) {
           int[] coords = new int[3];

           if (axis == 0) {
              coords[0] = deep;
              coords[1] = yi;
              coords[2] = xi;
           }
           else if (axis == 1) {
              coords[0] = xi;
              coords[1] = deep;
              coords[2] = yi;
           }
           else if (axis == 2) {
              coords[0] = xi;
              coords[1] = yi;
              coords[2] = deep;
           }
           return coords;
        }

        public static int[] getFaceCoords(int face, int x, int y)
        {
           int[,] coords = new int[9, 3];

           if (face == 1)
              coords = new int[9, 3] { { 1, 1, 4 }, { 2, 1, 4 }, { 3, 1, 4 }, { 1, 2, 4 }, { 2, 2, 4 }, { 3, 2, 4 }, { 1, 3, 4 }, { 2, 3, 4 }, { 3, 3, 4 } };
           else if (face == 2)
              coords = new int[9, 3] { { 1, 4, 3 }, { 2, 4, 3 }, { 3, 4, 3 }, { 1, 4, 2 }, { 2, 4, 2 }, { 3, 4, 2 }, { 1, 4, 1 }, { 2, 4, 1 }, { 3, 4, 1 } };
           else if (face == 3)
              coords = new int[9, 3] { { 1, 3, 0 }, { 2, 3, 0 }, { 3, 3, 0 }, { 1, 2, 0 }, { 2, 2, 0 }, { 3, 2, 0 }, { 1, 1, 0 }, { 2, 1, 0 }, { 3, 1, 0 } };
           else if (face == 4)
              coords = new int[9, 3] { { 1, 0, 1 }, { 2, 0, 1 }, { 3, 0, 1 }, { 1, 0, 2 }, { 2, 0, 2 }, { 3, 0, 2 }, { 1, 0, 3 }, { 2, 0, 3 }, { 3, 0, 3 } };
           else if (face == 5)
              coords = new int[9, 3] { { 0, 1, 3 }, { 0, 2, 3 }, { 0, 3, 3 }, { 0, 1, 2 }, { 0, 2, 2 }, { 0, 3, 2 }, { 0, 1, 1 }, { 0, 2, 1 }, { 0, 3, 1 } };
           else if (face == 6)
              coords = new int[9, 3] { { 4, 3, 3 }, { 4, 2, 3 }, { 4, 1, 3 }, { 4, 3, 2 }, { 4, 2, 2 }, { 4, 1, 2 }, { 4, 3, 1 }, { 4, 2, 1 }, { 4, 1, 1 } };

           int idx = y * 3 + x;

           int[] ret = new int[3];
           ret[0] = coords[idx, 0];
           ret[1] = coords[idx, 1];
           ret[2] = coords[idx, 2];

           return ret;
        }

        public static int[,] getFace(int[,,] cubex, int face)
        {           
           int[,] facex = new int[3, 3];

           for (int y = 0; y < 3; y++) { // líneas  Y
              for (int x = 0; x < 3; x++) // Columnas X
              {
                 int[] coords = getFaceCoords( face, x, y);
                  
                 facex[x, y] = cubex[coords[0], coords[1], coords[2]];
              }
           }
           return facex;
           
        }

       private static void rotateFaceAux(int[,,] cubeIn, int axis, int deep)
        {
          int[,] oldmatrix = get2dFace(cubeIn, axis, deep);
          int[,] newmatrix = RotateMatrixCounterClockwise(oldmatrix);

           for (int x = 0; x < 5; x++)
           {
              for (int y = 0; y < 5; y++)
              {
                 int[] coords = get3dCoords(axis, deep, x, y);
                 cubeIn[coords[0], coords[1], coords[2]] = newmatrix[x, y];
              }
           }
       }

       public void rotateFace( int axis, int level)
       {
           if (level == 1)
           {
              rotateFaceAux( this.cube, axis, 0);
              rotateFaceAux( this.cube, axis, 1);
           }
           else if (level == 2)
           {
              rotateFaceAux( this.cube, axis, 2);
           }
           else
           {
              rotateFaceAux( this.cube, axis, 3);
              rotateFaceAux( this.cube, axis, 4);
           }
        }
        
               
        // copia un disco del cubo maestro
        private void CopyFromMasterCube(int axis, int deep){
           int[,] disk = get2dFace(this.MasterCube, axis, deep);
           for (int x = 0; x < 5; x++) {
              for (int y = 0; y < 5; y++)
              {
                 int[] coords = get3dCoords(axis,deep,x,y);
                 this.cube[coords[0], coords[1], coords[2]] = disk[x, y];
              }
           }
        }
       
       // ----------------------------------------------------
       // Comparación del cubo desde cualquier punto de vista
       private bool cached = false;
       public int[][, ,] viewPoints = new int[24][, ,];

       private void contructViewPoints() {
          this.cached = true;

          RubikCube nc = new RubikCube();
          nc = this.Clone();
          int idx = 0;

          for (int y=0; y <= 3; y++ ){
             nc.rotateFace( 1, 1);
             nc.rotateFace( 1, 2);
             nc.rotateFace( 1, 3);
             for (int z = 0; z <= 3; z++)
             {
                nc.rotateFace(2, 1);
                nc.rotateFace(2, 2);
                nc.rotateFace(2, 3);
                this.viewPoints[idx++] = (int[, ,])nc.ToMatrix().Clone();
             }
          }

          for (int x = 0; x <= 3; x++) {
             nc.rotateFace(0, 1);
             nc.rotateFace(0, 2);
             nc.rotateFace(0, 3);
             if (x == 0 || x == 2) {
                for (int z = 0; z <= 3; z++)
                {
                   nc.rotateFace(2, 1);
                   nc.rotateFace(2, 2);
                   nc.rotateFace(2, 3);
                   this.viewPoints[idx++] = (int[,,])nc.ToMatrix().Clone();
                }
             }
          }

       }
       
       public override bool Equals(Object obj){
          if (!this.cached)
             contructViewPoints();

          RubikCube ToCompare = (RubikCube)obj;
          int[, ,] toCompareMatrix = ToCompare.ToMatrix();
          
          for (int idx = 0; idx < 24; idx++)
          {

             bool equal = true;

             // Se realiza la comparación. Aunte una incompatibilidad, se cancela.
             
             int x, y, z;
             
             for (int i = 0; i < 54 && equal; i++) {
                x = validPositions[i, 0];
                y = validPositions[i, 1];
                z = validPositions[i, 2];

                if (!(viewPoints[idx][x, y, z] == toCompareMatrix[x, y, z] ||  // número igual
                   toCompareMatrix[x, y, z] == 0 || viewPoints[idx][x, y, z] == 0// comodin                      
                   ))
                   equal = false;

             }
             if (equal)
                return true;
          }
          return false;
          
        }


       public RubikCube Clone()
       {
          RubikCube cubeaux = new RubikCube();
          cubeaux.fromMatrix( (int[,,])this.ToMatrix().Clone() );
          return cubeaux;
       }

       // Funciones auxiliares
       private static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = 0; oldColumn < oldMatrix.GetLength(1) ; oldColumn++)
            {
                newColumn = 0;
                for (int oldRow = oldMatrix.GetLength(0)-1; oldRow >= 0 ; oldRow--)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

       public static Color getColorByNum(int n)
       {
          switch (n)
          {
             case 1: return Color.Blue;
             case 2: return Color.Yellow;
             case 3: return Color.Green;
             case 4: return Color.White;
             case 5: return Color.Red;
             case 6: return Color.Orange;
          }
          return Color.Gray;
       }
       public  static int getNumByColor(Color c)
       {

          if (c == Color.Blue)
             return 1;
          else if (c == Color.Yellow)
             return 2;
          else if (c == Color.Green)
             return 3;
          else if (c == Color.White)
             return 4;
          else if (c == Color.Red)
             return 5;
          else if (c == Color.Orange)
             return 6;
          else return 0;

       }
    }
}
