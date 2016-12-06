using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MonzaRubikLib;

namespace WindowsFormsApplication1
{
   public partial class MainUI : Form //,MonzaRubikLib.IObserver
   {
      public MainUI()
      {
         InitializeComponent();
      }

      private RubikCube cubeA;
      private RubikCube cubeB;
      private RubikCube status;
      private AbstractAlgorithm alg;

      private RubikCubeUI UICubeA;
      private RubikCubeUI UICubeB;
      private RubikCubeUI UIStatus;
      private PaletteUI palette;
      
      private void Form1_Load(object sender, EventArgs e)
      {
         this.palette = new PaletteUI(this, 20, 80);

         this.cubeA = new RubikCube();
         this.cubeA.setRandom();
         
         this.UICubeA = new RubikCubeUI(this.cubeA, 55, 80, this);

         this.cubeB = new RubikCube();
         this.cubeB.setMasterCube();

         this.UICubeB = new RubikCubeUI(this.cubeB, 340, 80, this);

         this.status = new RubikCube();
         this.UIStatus = new RubikCubeUI(this.status, 625, 80, this);

         this.DoubleBuffered = true;
         System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;

         cmbClipboard.SelectedIndex=0;
         this.btnStop.Enabled = false;
         this.btnSolution.Enabled = false;

         cmbAlgorithm.Items.Add(new AlgorithmCombinations());
         cmbAlgorithm.SelectedIndex = 0;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         this.cubeA.clear();
         this.Invalidate(new Rectangle(UICubeA.X, UICubeA.Y, UICubeA.Width, UICubeA.Height));
      }

      private void button2_Click(object sender, EventArgs e)
      {
         int axis = 0;
         int level = 1;
         if (this.radioButtonY.Checked)
            axis = 1;
         else if (this.radioButtonZ.Checked)
            axis = 2;
         if (this.radioButton2.Checked)
            level = 2;
         else if (this.radioButton3.Checked)
            level = 3;

         this.cubeA.rotateFace( axis, level);
         this.Invalidate(new Rectangle( UICubeA.X, UICubeA.Y, UICubeA.Width, UICubeA.Height));
      }

      private void MainUI_MouseClick(object sender, MouseEventArgs e)
      {
         this.palette.click( e.X, e.Y);

         // Se invalida la paleta para que solo se dibuje esta

         // El evento click ya invalida la ficha que se colorea
         this.UICubeA.click( e.X, e.Y, this.palette.SelectedColor);
         this.ConsoleWrite(this.UICubeA.Status, false);
         this.Update();
      }

      private void updateForm(Graphics g)
      {
         this.UICubeA.draw(g);
         this.UICubeB.draw(g);
         this.UIStatus.draw(g);
         this.palette.draw(g);
         //this.lOperations.Text = RubikCube.operations.ToString();
      }
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         updateForm(e.Graphics);   
      }

      private void lOperations_Click(object sender, EventArgs e)
      {     }

      private void button3_Click(object sender, EventArgs e)
      {

         ChangeEnabled(false);
         this.btnStop.Enabled = true;
         this.ConsoleWrite("Resolving cube...", true);

         // this.alg = new AlgorithmRandom(3000000);
         this.alg = (AbstractAlgorithm)cmbAlgorithm.SelectedItem;

         alg.Resolve( this.cubeA, this.cubeB);

         while (!alg.IsCompleted)
         {
            // this.alg.doEvents();
            this.updateAlgStatus(alg.cubeStat);
            this.ConsoleWrite( alg.Status(), false);
            Application.DoEvents();
            
            this.Refresh();
            System.Threading.Thread.Sleep(500);
         }

         // Show solution
         ChangeEnabled(true);
         string sMoves = "";
         if (alg.cubeMatch != null)
         {
            foreach (Move m in this.alg.winnerMoves)
            {
               sMoves += m.ToString() + "  ";
            }
            this.ConsoleWrite(sMoves, false);
            btnSolution.Enabled = true;
         }
         else
         {
            btnSolution.Enabled = false;
            if (this.alg.IsCanceled)
               this.ConsoleWrite("Resolution canceled by user", false);
            else
               this.ConsoleWrite("There is not solution for this algorithm", false);
         }
         this.updateAlgStatus(alg.cubeMatch);
         this.Refresh();
         this.btnStop.Enabled = false;
      }

      private void updateAlgStatus(RubikCube cube) {
         this.lOperations.Text = this.alg.Operations.ToString();
         if (cube != null)
            status.fromMatrix(cube.ToMatrix());
         else
            status.clear();
         this.Invalidate(new Rectangle(this.UIStatus.X, this.UIStatus.Y, this.UIStatus.Width, this.UIStatus.Height));
         this.Update();
      }

      private void button4_Click(object sender, EventArgs e)
      {
         this.cubeA.setMasterCube();
         this.Refresh();
      }

      private void button5_Click(object sender, EventArgs e)
      {
         this.cubeA.setRandom();
         this.Refresh();
      }

      private void button6_Click(object sender, EventArgs e)
      {
         this.cubeB.setRandom();
         this.Refresh();
      }

      private void button7_Click(object sender, EventArgs e)
      {
         this.cubeB.setMasterCube();
         this.Refresh();
      }

      private void button8_Click(object sender, EventArgs e)
      {

         this.ConsoleWrite("Testing cube viewpoints...", true);

         RubikCube nc = this.cubeA.Clone();
         nc.Equals(this.cubeA);

         for (int idx = 0; idx < 24; idx++) {
            this.status.fromMatrix(nc.viewPoints[idx]);
            this.Refresh();

            this.ConsoleWrite( string.Format("Test #{0} CubeA compare: {1}", idx.ToString(), this.cubeA.Equals(this.status).ToString() ), false);
            System.Threading.Thread.Sleep(500);
            //MessageBox.Show("Next...");
         }

      }

      private void ConsoleWrite(string s, bool clear) {
         if (clear)
            txtConsole.Text = "";
         txtConsole.Text += s + "\r\n";

         txtConsole.SelectionStart = txtConsole.TextLength;
         txtConsole.ScrollToCaret();
      }

      private void txtConsole_VisibleChanged(object sender, EventArgs e)
      {
         txtConsole.SelectionStart = txtConsole.TextLength;
         txtConsole.ScrollToCaret();
      }

      private void btnCopyAToB_Click(object sender, EventArgs e)
      {
         this.cubeB.fromMatrix(this.cubeA.ToMatrix());
         this.Refresh();
      }

      private void btnCopyBToA_Click(object sender, EventArgs e)
      {
         this.cubeA.fromMatrix(this.cubeB.ToMatrix());
         this.Refresh();
      }

      private void btnToClipboard_Click(object sender, EventArgs e)
      {
         if (this.cmbClipboard.SelectedIndex==0)
            Clipboard.SetText(this.cubeA.ToString());
         else if (this.cmbClipboard.SelectedIndex==1)
            Clipboard.SetText(this.cubeB.ToString());
         else
            Clipboard.SetText(this.status.ToString());

      }

      private void btnFromClipboard_Click(object sender, EventArgs e)
      {
         try
         {
            if (this.cmbClipboard.SelectedIndex == 0)
               this.cubeA.fromString(Clipboard.GetText());
            else if (this.cmbClipboard.SelectedIndex==1)
               this.cubeB.fromString(Clipboard.GetText());
            else
               this.status.fromString(Clipboard.GetText());

            this.Refresh();
         }
         catch { MessageBox.Show("Error bulding cube from clipboard"); }
      }

      private void btnStop_Click(object sender, EventArgs e)
      {
         this.alg.Cancel();
      }

      private void btnSolution_Click(object sender, EventArgs e)
      {
         btnSolution.Enabled = false;
         foreach(Move m in this.alg.winnerMoves){
            for (int i = 1; i <= m.Turns; i++)
            {
               this.cubeA.rotateFace(m.Axis, m.Level);
               this.Refresh();
               System.Threading.Thread.Sleep(300);
            }
         }
      }

      void ChangeEnabled(bool enabled)
      {
         foreach (Control c in this.Controls)
         {
            if (c.Name != "txtConsole")
               c.Enabled = enabled;
         }

      }
   }

}
