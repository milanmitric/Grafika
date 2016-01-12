﻿namespace RGProj1
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openGlControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.btn_reset = new System.Windows.Forms.Button();
            this.timerAvion = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timerSijalice = new System.Windows.Forms.Timer(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericSFactor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // openGlControl
            // 
            this.openGlControl.AccumBits = ((byte)(0));
            this.openGlControl.AutoCheckErrors = false;
            this.openGlControl.AutoFinish = false;
            this.openGlControl.AutoMakeCurrent = true;
            this.openGlControl.AutoSwapBuffers = true;
            this.openGlControl.BackColor = System.Drawing.Color.Black;
            this.openGlControl.ColorBits = ((byte)(32));
            this.openGlControl.DepthBits = ((byte)(16));
            this.openGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGlControl.Location = new System.Drawing.Point(0, 0);
            this.openGlControl.Name = "openGlControl";
            this.openGlControl.Size = new System.Drawing.Size(798, 578);
            this.openGlControl.StencilBits = ((byte)(0));
            this.openGlControl.TabIndex = 1;
            this.openGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.openGlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGlControlKeyDown);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(12, 543);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "Reload";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // timerAvion
            // 
            this.timerAvion.Tick += new System.EventHandler(this.timerAvion_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "zuta",
            "plava",
            "crvena",
            "zelena",
            "bela"});
            this.comboBox1.Location = new System.Drawing.Point(711, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "zuta";
            // 
            // timerSijalice
            // 
            this.timerSijalice.Interval = 1000;
            this.timerSijalice.Tick += new System.EventHandler(this.timerSijalice_Tick);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5 sekundi",
            "4 sekunde",
            "3 sekunde",
            "2 sekunde",
            "1 sekund",
            "0.5 sekundi",
            "0.1 sekundi"});
            this.comboBox2.Location = new System.Drawing.Point(666, 76);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "1 sekund";
            // 
            // numericSFactor
            // 
            this.numericSFactor.Location = new System.Drawing.Point(666, 116);
            this.numericSFactor.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericSFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSFactor.Name = "numericSFactor";
            this.numericSFactor.Size = new System.Drawing.Size(120, 20);
            this.numericSFactor.TabIndex = 6;
            this.numericSFactor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSFactor.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Skaliranje sijalica";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 578);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSFactor);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.openGlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projektni zadatak 6.2 – Poletanje aviona";
            ((System.ComponentModel.ISupportInitialize)(this.numericSFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openGlControl;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Timer timerAvion;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timerSijalice;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericSFactor;
        private System.Windows.Forms.Label label1;
    }
}

