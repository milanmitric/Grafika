namespace RGProj1
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
            this.timerSijalice = new System.Windows.Forms.Timer(this.components);
            this.numericSFactor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericSInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericGreen = new System.Windows.Forms.NumericUpDown();
            this.numericRed = new System.Windows.Forms.NumericUpDown();
            this.numericBlue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).BeginInit();
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
            // timerSijalice
            // 
            this.timerSijalice.Interval = 1000;
            this.timerSijalice.Tick += new System.EventHandler(this.timerSijalice_Tick);
            // 
            // numericSFactor
            // 
            this.numericSFactor.Location = new System.Drawing.Point(666, 146);
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
            this.label1.Location = new System.Drawing.Point(699, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Skaliranje sijalica";
            // 
            // numericSInterval
            // 
            this.numericSInterval.Location = new System.Drawing.Point(666, 107);
            this.numericSInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSInterval.Name = "numericSInterval";
            this.numericSInterval.Size = new System.Drawing.Size(120, 20);
            this.numericSInterval.TabIndex = 8;
            this.numericSInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Interval za sijalice u sekundama";
            // 
            // numericGreen
            // 
            this.numericGreen.Location = new System.Drawing.Point(540, 68);
            this.numericGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericGreen.Name = "numericGreen";
            this.numericGreen.Size = new System.Drawing.Size(120, 20);
            this.numericGreen.TabIndex = 10;
            // 
            // numericRed
            // 
            this.numericRed.Location = new System.Drawing.Point(414, 68);
            this.numericRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericRed.Name = "numericRed";
            this.numericRed.Size = new System.Drawing.Size(120, 20);
            this.numericRed.TabIndex = 11;
            this.numericRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // numericBlue
            // 
            this.numericBlue.Location = new System.Drawing.Point(666, 68);
            this.numericBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericBlue.Name = "numericBlue";
            this.numericBlue.Size = new System.Drawing.Size(120, 20);
            this.numericBlue.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(623, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "RGB komponenta za boju sijalica";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 578);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericBlue);
            this.Controls.Add(this.numericRed);
            this.Controls.Add(this.numericGreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericSInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericSFactor);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.openGlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projektni zadatak 6.2 – Poletanje aviona";
            ((System.ComponentModel.ISupportInitialize)(this.numericSFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openGlControl;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Timer timerAvion;
        private System.Windows.Forms.Timer timerSijalice;
        private System.Windows.Forms.NumericUpDown numericSFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericSInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericGreen;
        private System.Windows.Forms.NumericUpDown numericRed;
        private System.Windows.Forms.NumericUpDown numericBlue;
        private System.Windows.Forms.Label label3;
    }
}

