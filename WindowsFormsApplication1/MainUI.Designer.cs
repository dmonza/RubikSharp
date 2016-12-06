namespace WindowsFormsApplication1
{
   partial class MainUI
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.lOperations = new System.Windows.Forms.Label();
         this.button3 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButtonZ = new System.Windows.Forms.RadioButton();
         this.radioButtonY = new System.Windows.Forms.RadioButton();
         this.radioButtonX = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.radioButton3 = new System.Windows.Forms.RadioButton();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.button4 = new System.Windows.Forms.Button();
         this.button5 = new System.Windows.Forms.Button();
         this.button6 = new System.Windows.Forms.Button();
         this.button7 = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.txtConsole = new System.Windows.Forms.TextBox();
         this.button8 = new System.Windows.Forms.Button();
         this.btnCopyAToB = new System.Windows.Forms.Button();
         this.btnCopyBToA = new System.Windows.Forms.Button();
         this.btnToClipboard = new System.Windows.Forms.Button();
         this.btnFromClipboard = new System.Windows.Forms.Button();
         this.cmbClipboard = new System.Windows.Forms.ComboBox();
         this.panel3 = new System.Windows.Forms.Panel();
         this.btnStop = new System.Windows.Forms.Button();
         this.btnSolution = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(75, 41);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "Blank";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(236, 443);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "Rotate";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // lOperations
         // 
         this.lOperations.AutoSize = true;
         this.lOperations.Location = new System.Drawing.Point(834, 46);
         this.lOperations.Name = "lOperations";
         this.lOperations.Size = new System.Drawing.Size(35, 13);
         this.lOperations.TabIndex = 2;
         this.lOperations.Text = "label1";
         this.lOperations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.lOperations.Click += new System.EventHandler(this.lOperations_Click);
         // 
         // button3
         // 
         this.button3.BackColor = System.Drawing.Color.LimeGreen;
         this.button3.Location = new System.Drawing.Point(617, 36);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(114, 33);
         this.button3.TabIndex = 3;
         this.button3.Text = "Resolve (A->B)";
         this.button3.UseVisualStyleBackColor = false;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButtonZ);
         this.groupBox1.Controls.Add(this.radioButtonY);
         this.groupBox1.Controls.Add(this.radioButtonX);
         this.groupBox1.Location = new System.Drawing.Point(22, 433);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(101, 33);
         this.groupBox1.TabIndex = 7;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Axis";
         // 
         // radioButtonZ
         // 
         this.radioButtonZ.AutoSize = true;
         this.radioButtonZ.Location = new System.Drawing.Point(64, 11);
         this.radioButtonZ.Name = "radioButtonZ";
         this.radioButtonZ.Size = new System.Drawing.Size(32, 17);
         this.radioButtonZ.TabIndex = 9;
         this.radioButtonZ.TabStop = true;
         this.radioButtonZ.Text = "Z";
         this.radioButtonZ.UseVisualStyleBackColor = true;
         // 
         // radioButtonY
         // 
         this.radioButtonY.AutoSize = true;
         this.radioButtonY.Location = new System.Drawing.Point(35, 11);
         this.radioButtonY.Name = "radioButtonY";
         this.radioButtonY.Size = new System.Drawing.Size(32, 17);
         this.radioButtonY.TabIndex = 8;
         this.radioButtonY.Text = "Y";
         this.radioButtonY.UseVisualStyleBackColor = true;
         // 
         // radioButtonX
         // 
         this.radioButtonX.AutoSize = true;
         this.radioButtonX.Checked = true;
         this.radioButtonX.Location = new System.Drawing.Point(6, 11);
         this.radioButtonX.Name = "radioButtonX";
         this.radioButtonX.Size = new System.Drawing.Size(32, 17);
         this.radioButtonX.TabIndex = 7;
         this.radioButtonX.TabStop = true;
         this.radioButtonX.Text = "X";
         this.radioButtonX.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.radioButton3);
         this.groupBox2.Controls.Add(this.radioButton2);
         this.groupBox2.Controls.Add(this.radioButton1);
         this.groupBox2.Location = new System.Drawing.Point(129, 433);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(101, 33);
         this.groupBox2.TabIndex = 10;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Level";
         // 
         // radioButton3
         // 
         this.radioButton3.AutoSize = true;
         this.radioButton3.Location = new System.Drawing.Point(64, 11);
         this.radioButton3.Name = "radioButton3";
         this.radioButton3.Size = new System.Drawing.Size(31, 17);
         this.radioButton3.TabIndex = 9;
         this.radioButton3.TabStop = true;
         this.radioButton3.Text = "3";
         this.radioButton3.UseVisualStyleBackColor = true;
         // 
         // radioButton2
         // 
         this.radioButton2.AutoSize = true;
         this.radioButton2.Location = new System.Drawing.Point(35, 11);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(31, 17);
         this.radioButton2.TabIndex = 8;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "2";
         this.radioButton2.UseVisualStyleBackColor = true;
         // 
         // radioButton1
         // 
         this.radioButton1.AutoSize = true;
         this.radioButton1.Checked = true;
         this.radioButton1.Location = new System.Drawing.Point(6, 11);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(31, 17);
         this.radioButton1.TabIndex = 7;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "1";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // button4
         // 
         this.button4.Location = new System.Drawing.Point(156, 41);
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size(75, 23);
         this.button4.TabIndex = 11;
         this.button4.Text = "Reset";
         this.button4.UseVisualStyleBackColor = true;
         this.button4.Click += new System.EventHandler(this.button4_Click);
         // 
         // button5
         // 
         this.button5.Location = new System.Drawing.Point(237, 41);
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size(75, 23);
         this.button5.TabIndex = 12;
         this.button5.Text = "Random";
         this.button5.UseVisualStyleBackColor = true;
         this.button5.Click += new System.EventHandler(this.button5_Click);
         // 
         // button6
         // 
         this.button6.Location = new System.Drawing.Point(523, 41);
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size(75, 23);
         this.button6.TabIndex = 15;
         this.button6.Text = "Random";
         this.button6.UseVisualStyleBackColor = true;
         this.button6.Click += new System.EventHandler(this.button6_Click);
         // 
         // button7
         // 
         this.button7.Location = new System.Drawing.Point(443, 41);
         this.button7.Name = "button7";
         this.button7.Size = new System.Drawing.Size(75, 23);
         this.button7.TabIndex = 14;
         this.button7.Text = "Reset";
         this.button7.UseVisualStyleBackColor = true;
         this.button7.Click += new System.EventHandler(this.button7_Click);
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.Color.DimGray;
         this.panel1.Location = new System.Drawing.Point(323, 32);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(3, 454);
         this.panel1.TabIndex = 16;
         // 
         // panel2
         // 
         this.panel2.BackColor = System.Drawing.Color.DimGray;
         this.panel2.Location = new System.Drawing.Point(608, 33);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(3, 454);
         this.panel2.TabIndex = 17;
         // 
         // txtConsole
         // 
         this.txtConsole.BackColor = System.Drawing.SystemColors.Window;
         this.txtConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.txtConsole.Location = new System.Drawing.Point(0, 474);
         this.txtConsole.Multiline = true;
         this.txtConsole.Name = "txtConsole";
         this.txtConsole.ReadOnly = true;
         this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtConsole.Size = new System.Drawing.Size(906, 78);
         this.txtConsole.TabIndex = 18;
         this.txtConsole.VisibleChanged += new System.EventHandler(this.txtConsole_VisibleChanged);
         // 
         // button8
         // 
         this.button8.Location = new System.Drawing.Point(639, 441);
         this.button8.Name = "button8";
         this.button8.Size = new System.Drawing.Size(112, 23);
         this.button8.TabIndex = 19;
         this.button8.Text = "Test A ViewPoints";
         this.button8.UseVisualStyleBackColor = true;
         this.button8.Click += new System.EventHandler(this.button8_Click);
         // 
         // btnCopyAToB
         // 
         this.btnCopyAToB.Location = new System.Drawing.Point(242, 270);
         this.btnCopyAToB.Name = "btnCopyAToB";
         this.btnCopyAToB.Size = new System.Drawing.Size(75, 23);
         this.btnCopyAToB.TabIndex = 20;
         this.btnCopyAToB.Text = "Copy >";
         this.btnCopyAToB.UseVisualStyleBackColor = true;
         this.btnCopyAToB.Click += new System.EventHandler(this.btnCopyAToB_Click);
         // 
         // btnCopyBToA
         // 
         this.btnCopyBToA.Location = new System.Drawing.Point(332, 270);
         this.btnCopyBToA.Name = "btnCopyBToA";
         this.btnCopyBToA.Size = new System.Drawing.Size(75, 23);
         this.btnCopyBToA.TabIndex = 21;
         this.btnCopyBToA.Text = "< Copy";
         this.btnCopyBToA.UseVisualStyleBackColor = true;
         this.btnCopyBToA.Click += new System.EventHandler(this.btnCopyBToA_Click);
         // 
         // btnToClipboard
         // 
         this.btnToClipboard.Location = new System.Drawing.Point(805, 3);
         this.btnToClipboard.Name = "btnToClipboard";
         this.btnToClipboard.Size = new System.Drawing.Size(89, 23);
         this.btnToClipboard.TabIndex = 22;
         this.btnToClipboard.Text = "To Clipboard";
         this.btnToClipboard.UseVisualStyleBackColor = true;
         this.btnToClipboard.Click += new System.EventHandler(this.btnToClipboard_Click);
         // 
         // btnFromClipboard
         // 
         this.btnFromClipboard.Location = new System.Drawing.Point(616, 3);
         this.btnFromClipboard.Name = "btnFromClipboard";
         this.btnFromClipboard.Size = new System.Drawing.Size(125, 23);
         this.btnFromClipboard.TabIndex = 23;
         this.btnFromClipboard.Text = "From Clipboard TO:";
         this.btnFromClipboard.UseVisualStyleBackColor = true;
         this.btnFromClipboard.Click += new System.EventHandler(this.btnFromClipboard_Click);
         // 
         // cmbClipboard
         // 
         this.cmbClipboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbClipboard.FormattingEnabled = true;
         this.cmbClipboard.Items.AddRange(new object[] {
            "A",
            "B",
            "Status"});
         this.cmbClipboard.Location = new System.Drawing.Point(746, 4);
         this.cmbClipboard.Name = "cmbClipboard";
         this.cmbClipboard.Size = new System.Drawing.Size(52, 21);
         this.cmbClipboard.TabIndex = 24;
         // 
         // panel3
         // 
         this.panel3.BackColor = System.Drawing.Color.DimGray;
         this.panel3.Location = new System.Drawing.Point(0, 30);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(909, 3);
         this.panel3.TabIndex = 17;
         // 
         // btnStop
         // 
         this.btnStop.Location = new System.Drawing.Point(737, 36);
         this.btnStop.Name = "btnStop";
         this.btnStop.Size = new System.Drawing.Size(61, 33);
         this.btnStop.TabIndex = 25;
         this.btnStop.Text = "Stop";
         this.btnStop.UseVisualStyleBackColor = true;
         this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
         // 
         // btnSolution
         // 
         this.btnSolution.Location = new System.Drawing.Point(757, 441);
         this.btnSolution.Name = "btnSolution";
         this.btnSolution.Size = new System.Drawing.Size(112, 23);
         this.btnSolution.TabIndex = 26;
         this.btnSolution.Text = "Exec Solution";
         this.btnSolution.UseVisualStyleBackColor = true;
         this.btnSolution.Click += new System.EventHandler(this.btnSolution_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(106, 13);
         this.label1.TabIndex = 27;
         this.label1.Text = "Resolution Algorithm:";
         // 
         // cmbAlgorithm
         // 
         this.cmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbAlgorithm.FormattingEnabled = true;
         this.cmbAlgorithm.Location = new System.Drawing.Point(124, 5);
         this.cmbAlgorithm.Name = "cmbAlgorithm";
         this.cmbAlgorithm.Size = new System.Drawing.Size(121, 21);
         this.cmbAlgorithm.TabIndex = 28;
         // 
         // MainUI
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(906, 552);
         this.Controls.Add(this.cmbAlgorithm);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.btnSolution);
         this.Controls.Add(this.btnStop);
         this.Controls.Add(this.panel3);
         this.Controls.Add(this.cmbClipboard);
         this.Controls.Add(this.btnFromClipboard);
         this.Controls.Add(this.btnToClipboard);
         this.Controls.Add(this.btnCopyBToA);
         this.Controls.Add(this.btnCopyAToB);
         this.Controls.Add(this.button8);
         this.Controls.Add(this.txtConsole);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.button6);
         this.Controls.Add(this.lOperations);
         this.Controls.Add(this.button7);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.button5);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.button4);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainUI";
         this.Text = "Monza Rubik\'s Cube Framework .net";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainUI_MouseClick);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Label lOperations;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton radioButtonZ;
      private System.Windows.Forms.RadioButton radioButtonY;
      private System.Windows.Forms.RadioButton radioButtonX;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.RadioButton radioButton3;
      private System.Windows.Forms.RadioButton radioButton2;
      private System.Windows.Forms.RadioButton radioButton1;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.Button button5;
      private System.Windows.Forms.Button button6;
      private System.Windows.Forms.Button button7;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.TextBox txtConsole;
      private System.Windows.Forms.Button button8;
      private System.Windows.Forms.Button btnCopyAToB;
      private System.Windows.Forms.Button btnCopyBToA;
      private System.Windows.Forms.Button btnToClipboard;
      private System.Windows.Forms.Button btnFromClipboard;
      private System.Windows.Forms.ComboBox cmbClipboard;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnStop;
      private System.Windows.Forms.Button btnSolution;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox cmbAlgorithm;
   }
}

