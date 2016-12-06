using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
   public class PaletteUI
   {
      private int offsetX;
      private int offsetY;
      private Form form;
      private Color _selectedColor;
      
      public double Scale = .7;

      public PaletteUI(Form f, int poffsetX, int poffsetY) {
         this.form = f;
         this._selectedColor = Color.Gray;
         this.offsetX = poffsetX;
         this.offsetY = poffsetY;
      }

      public Color SelectedColor { get { return this._selectedColor; } }

      private int Side { get { return (int)(40 * this.Scale); } }
      public int X { get { return offsetX; } }
      public int Y { get { return offsetY; } }
      public int Width { get { return Side; } }
      public int Height { get { return (Side * 8)+ Side; } }

      public void draw(Graphics g) {
         Pen p = new Pen(Color.Black);
         for (int c = 0; c <= 6; c++)
         {
            g.FillRectangle(new SolidBrush(getColorByNum(c)), this.X, this.Y + (Side * c), Side, Side);
            g.DrawRectangle(p, this.X, this.Y + (Side * c), Side, Side);
         }

         g.FillRectangle(new SolidBrush(this.SelectedColor), this.X, this.Y + (Side * 8), Side, Side);
         g.DrawRectangle(p, this.X, this.Y + (Side * 8), Side, Side);
      }

      private Color getColorByNum(int n)
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

      public void click(int x, int y) {
         for (int c = 0; c <= 6; c++)
         {
            if (this.offsetX <= x && x <= Side + this.offsetX &&
               offsetY + (Side * c) <= y &&
               y <= offsetY + (Side * c) + Side)
            {
               this._selectedColor = getColorByNum(c);
               this.form.Invalidate(new Rectangle(this.X, this.Y + (Side * 8), Side, Side));
            }
         }
      }
   }
}
