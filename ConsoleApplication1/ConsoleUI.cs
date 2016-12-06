using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonzaRubikLib;

namespace ConsoleApplication1
{
    public class ConsoleUI
    {
        public RubikCube CubeA;
        //public RubikCube CubeB;
        

        public ConsoleUI() {
            this.CubeA = new RubikCube();
            //this.CubeB = new RubikCube(true);
        }

        public void Show() {
           //this.CubeA.CopyFace(2);

           this.CubeA.setMasterCube();
           this.CubeA.rotateFace( 1, 3);
           this.drawCube(this.CubeA.ToMatrix());
            
            string cmd = "";
            
            while (cmd != "QUIT") {
               if (cmd.Trim() != "")
               {
                  if (cmd == "D")
                     this.drawCube(this.CubeA.ToMatrix());
                  else if (cmd == "CLEAR")
                     this.CubeA.clear();
                  else if (cmd.Substring(0, 1) == "R" && cmd.Length == 3)
                  {
                     int Level = Convert.ToInt32(cmd.Substring(2, 1));
                     Console.WriteLine("Rotating Axis: " + cmd.Substring(1, 1) + " Level: " + Level.ToString());

                     if (cmd.Substring(1, 1) == "X")
                        this.CubeA.rotateFace( 0, Level);
                     if (cmd.Substring(1, 1) == "Y")
                        this.CubeA.rotateFace( 1, Level);
                     if (cmd.Substring(1, 1) == "Z")
                        this.CubeA.rotateFace( 2, Level);
                  }
                  else if (cmd.Substring(0, 1) == "P" && cmd.Length == 5)
                  {
                     Console.WriteLine("Painting...");

                     int face = Convert.ToInt32( cmd.Substring(1, 1));
                     int x = Convert.ToInt32(cmd.Substring(2, 1));
                     int y = Convert.ToInt32(cmd.Substring(3, 1));
                     int z = Convert.ToInt32(cmd.Substring(4, 1));
                     // this.CubeA.paint(face,x,y,z);
                  }
               }
               cmd = Console.ReadLine().ToUpper();
            }
        }
        public void drawCube(int[,,] cubex)
        {
           drawCubeFace(cubex,1);
           drawCubeFaceLarge(cubex);
           drawCubeFace(cubex,3);
           drawCubeFace(cubex,4);
           //Console.WriteLine(RubikCube.comprarCubos( this.CubeA.MasterCube, this.CubeA.WorkingCube).ToString());
           Console.WriteLine("");
        }

        private void drawCubeFace(int[,,] cubex, int face)
        {
            Console.WriteLine("         ----------");
            for (int l = 0; l < 3; l++) {
                Console.Write("         ");
                for (int c = 0; c < 3; c++)
                {
                   Console.Write("|" + getColorByNum(RubikCube.getFace(cubex,face)[l, c]));
                    //Console.Write("|" + ((this.Cube.getFace(face)[l, c] < 10)?"0":"") + this.Cube.getFace(face)[l, c].ToString());

                }
                Console.WriteLine("|");
            }

        }
        private void drawCubeFaceLarge(int[, ,] cubex)
        {
            for (int l = 0; l < 3; l++)
            {
                Console.WriteLine("----------------------------");
                drawLine(RubikCube.getFace(cubex,5), l);
                drawLine(RubikCube.getFace(cubex, 2), l);
                drawLine(RubikCube.getFace(cubex, 6), l);
                Console.WriteLine("|");
            }

        }
        private void drawLine(int[,] face, int l){

            for (int c = 0; c < 3; c++)
            {
                //Console.Write("|" + ((face[l, c] < 10) ? "0" : "") + face[l, c].ToString());
               Console.Write("|" + getColorByNum(face[l, c]));
            }
        }

        private string getColorByNum(int n) { 
           //int side = this.CubeA.getSideByNumber(n);
           int side = 0;
           switch (side) { 
              case 0: return "??";
              case 1: return "AZ";
              case 2: return "AM";
              case 3: return "VE";
              case 4: return "BL";
              case 5: return "RO";
              case 6: return "NA";
           }
           return "  ";
        }
       
    }
}
