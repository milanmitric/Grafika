namespace RacunarskaGrafika.Vezbe.AssimpNetSample
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
            this.m_world.Dispose();
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
            this.openglControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.openglTimer = new System.Windows.Forms.Timer(this.components);
            this.Kontrole = new System.Windows.Forms.GroupBox();
            this.lTranslate = new System.Windows.Forms.Label();
            this.lScale = new System.Windows.Forms.Label();
            this.lSceneDist = new System.Windows.Forms.Label();
            this.numTranslate = new System.Windows.Forms.NumericUpDown();
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.numSceneDist = new System.Windows.Forms.NumericUpDown();
            this.Kontrole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSceneDist)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl
            // 
            this.openglControl.AccumBits = ((byte)(0));
            this.openglControl.AutoCheckErrors = false;
            this.openglControl.AutoFinish = false;
            this.openglControl.AutoMakeCurrent = true;
            this.openglControl.AutoSwapBuffers = true;
            this.openglControl.BackColor = System.Drawing.Color.Black;
            this.openglControl.ColorBits = ((byte)(32));
            this.openglControl.DepthBits = ((byte)(16));
            this.openglControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openglControl.Location = new System.Drawing.Point(0, 0);
            this.openglControl.Name = "openglControl";
            this.openglControl.Size = new System.Drawing.Size(1007, 562);
            this.openglControl.StencilBits = ((byte)(0));
            this.openglControl.TabIndex = 1;
            this.openglControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.openglControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGlControlKeyDown);
            this.openglControl.Resize += new System.EventHandler(this.OpenGlControlResize);
            // 
            // openglTimer
            // 
            this.openglTimer.Enabled = true;
            this.openglTimer.Interval = 50;
            this.openglTimer.Tick += new System.EventHandler(this.OpenGlTimerTick);
            // 
            // Kontrole
            // 
            this.Kontrole.AutoSize = true;
            this.Kontrole.Controls.Add(this.lTranslate);
            this.Kontrole.Controls.Add(this.lScale);
            this.Kontrole.Controls.Add(this.lSceneDist);
            this.Kontrole.Controls.Add(this.numTranslate);
            this.Kontrole.Controls.Add(this.numScale);
            this.Kontrole.Controls.Add(this.numSceneDist);
            this.Kontrole.Dock = System.Windows.Forms.DockStyle.Right;
            this.Kontrole.Location = new System.Drawing.Point(812, 0);
            this.Kontrole.Name = "Kontrole";
            this.Kontrole.Size = new System.Drawing.Size(195, 562);
            this.Kontrole.TabIndex = 2;
            this.Kontrole.TabStop = false;
            this.Kontrole.Text = "Kontrole";
            // 
            // lTranslate
            // 
            this.lTranslate.AutoSize = true;
            this.lTranslate.Location = new System.Drawing.Point(6, 121);
            this.lTranslate.Name = "lTranslate";
            this.lTranslate.Size = new System.Drawing.Size(88, 13);
            this.lTranslate.TabIndex = 5;
            this.lTranslate.Text = "Brzina pomeranja";
            // 
            // lScale
            // 
            this.lScale.AutoSize = true;
            this.lScale.Location = new System.Drawing.Point(6, 73);
            this.lScale.Name = "lScale";
            this.lScale.Size = new System.Drawing.Size(79, 13);
            this.lScale.TabIndex = 4;
            this.lScale.Text = "Veličina aviona";
            // 
            // lSceneDist
            // 
            this.lSceneDist.AutoSize = true;
            this.lSceneDist.Location = new System.Drawing.Point(6, 26);
            this.lSceneDist.Name = "lSceneDist";
            this.lSceneDist.Size = new System.Drawing.Size(57, 13);
            this.lSceneDist.TabIndex = 3;
            this.lSceneDist.Text = "Udaljenost";
            // 
            // numTranslate
            // 
            this.numTranslate.Location = new System.Drawing.Point(121, 114);
            this.numTranslate.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numTranslate.Name = "numTranslate";
            this.numTranslate.Size = new System.Drawing.Size(68, 20);
            this.numTranslate.TabIndex = 2;
            this.numTranslate.ValueChanged += new System.EventHandler(this.NumTranslateValueChanged);
            // 
            // numScale
            // 
            this.numScale.Location = new System.Drawing.Point(121, 66);
            this.numScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numScale.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(68, 20);
            this.numScale.TabIndex = 1;
            this.numScale.ValueChanged += new System.EventHandler(this.NumScaleValueChanged);
            // 
            // numSceneDist
            // 
            this.numSceneDist.Location = new System.Drawing.Point(121, 19);
            this.numSceneDist.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numSceneDist.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numSceneDist.Name = "numSceneDist";
            this.numSceneDist.Size = new System.Drawing.Size(68, 20);
            this.numSceneDist.TabIndex = 0;
            this.numSceneDist.ValueChanged += new System.EventHandler(this.NumSceneDistanceValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1007, 562);
            this.Controls.Add(this.Kontrole);
            this.Controls.Add(this.openglControl);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zadatak 6.2";
            this.Kontrole.ResumeLayout(false);
            this.Kontrole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSceneDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openglControl;
        private System.Windows.Forms.Timer openglTimer;
        private System.Windows.Forms.GroupBox Kontrole;
        private System.Windows.Forms.NumericUpDown numTranslate;
        private System.Windows.Forms.NumericUpDown numScale;
        private System.Windows.Forms.NumericUpDown numSceneDist;
        private System.Windows.Forms.Label lTranslate;
        private System.Windows.Forms.Label lScale;
        private System.Windows.Forms.Label lSceneDist;
    }
}

