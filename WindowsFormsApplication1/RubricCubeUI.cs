using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MonzaRubikLib;

namespace WindowsFormsApplication1
{
   public class RubikCubeUI
   {
      public RubikCube Cube;
      private int offsetX;
      private int offsetY;
      private Form form;
      public double Scale = .7;

      private int[,,] squares;


      public int X { get { return offsetX; } }
      public int Y { get { return offsetY; } }
      public int Width { get { return this.offsetX + Side * 9; } }
      public int Height { get { return this.offsetY + Side * 12; } }

      private int Side { get { return (int) (40 * this.Scale); } }

      public RubikCubeUI(RubikCube cube, int xi, int yi, Form f)
      {
         this.Cube = cube;

         // this.Cube.UpdateCube += new RubikCube.updateCubeHandler(updateCube);

         this.offsetX = xi;
         this.offsetY = yi;
         this.form = f;

         // Calculo en memoria la posición de los cuadrados
         this.calcFaces();
      }

      public void draw(Graphics g) {
         if (this.Cube!=null)
            draw(g, this.Cube);
      }

      public void draw(Graphics g, RubikCube cubep){
         if (cubep == null)
            cubep = new RubikCube();

         Pen p = new Pen(Color.Black); 

         int x, y;
         for (int faceid = 0; faceid < 6; faceid++)
         {
            int[,] face = MonzaRubikLib.RubikCube.getFace(cubep.ToMatrix(), faceid + 1); //MonzaRubikLib.RubikCube

            for (int idx = 0; idx < 9; idx++)
            {
               x = this.squares[faceid, idx, 2];
               y = this.squares[faceid, idx, 3];
               g.FillRectangle(new SolidBrush(RubikCube.getColorByNum(face[x, y])), this.squares[faceid, idx, 0], this.squares[faceid, idx, 1], Side, Side);
               g.DrawRectangle( p, this.squares[faceid, idx, 0], this.squares[faceid, idx, 1], Side, Side);
            }
         }
      }
      
      private void calcFaces() {
         this.squares = new int[6,9,4];

         this.calcFacesAux(1, this.offsetX + Side * 3, this.offsetY + 0);
         this.calcFacesAux(2, this.offsetX + Side * 3, this.offsetY + Side * 3);
         this.calcFacesAux(3, this.offsetX + Side * 3, this.offsetY + Side * 6);
         this.calcFacesAux(4, this.offsetX + Side * 3, this.offsetY + Side * 9);

         this.calcFacesAux(5, this.offsetX + 0, this.offsetY + Side * 3);
         this.calcFacesAux(6, this.offsetX + Side * 6, this.offsetY + Side * 3);
      }
      private void calcFacesAux(int face, int xo, int yo)
      {
         int idx =0;
         for (int y = 0; y < 3; y++)
         {
            for (int x = 0; x < 3; x++)
            {
               this.squares[face-1,idx, 0] = xo + (Side * x);
               this.squares[face-1,idx, 1] = yo + (Side * y);
               this.squares[face-1,idx, 2] = x;
               this.squares[face-1,idx, 3] = y;
               idx++;
            }
         }
      }

      


      public void click( int x, int y, Color color)
      {
         for (int faceid = 0; faceid < 6; faceid++)
         {
            //int[,] face = MonzaRubikLib.RubikCube.getFace(cube, faceid + 1);

            for (int idx = 0; idx < 9; idx++)
            {
               if (
                  this.squares[faceid, idx, 0] < x && x<this.squares[faceid, idx, 0]+Side &&
                  this.squares[faceid, idx, 1] < y && y<this.squares[faceid, idx, 1]+Side
                  ){
                     int[] coords = MonzaRubikLib.RubikCube.getFaceCoords(faceid + 1, this.squares[faceid, idx, 2],this.squares[faceid, idx, 3]);
                     this.Cube.ToMatrix()[coords[0], coords[1], coords[2]] = RubikCube.getNumByColor(color);
                     this.status = string.Format("X:{0} Y:{1} Z:{2}", coords[0], coords[1], coords[2]);
                     
                     //g.FillRectangle(new SolidBrush(this.getColorByNum(face[x, y])), this.squares[faceid, idx, 0], this.squares[faceid, idx, 1], Side, Side);
                     //g.DrawRectangle(p, this.squares[faceid, idx, 0], this.squares[faceid, idx, 1], Side, Side);
                     this.form.Invalidate(new Rectangle(this.squares[faceid, idx, 0], this.squares[faceid, idx, 1], Side, Side));
               }
            }
         }
      }
      private string status;
      public string Status { get { return status; } }
   }
}
