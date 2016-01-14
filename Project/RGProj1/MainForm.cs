using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Assimp;
using System.Threading;

namespace RGProj1
{
    public partial class MainForm : Form
    {

        #region Atributi

        World m_world = null;
        private bool animacija;
        #endregion Atributi

        #region Konstruktori

        public MainForm()
        {
            InitializeComponent();

            openGlControl.InitializeContexts();
            timerSijalice.Enabled = true;
            try
            {
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Model\\Avion"), "BA 737-800.3ds", openGlControl.Width, openGlControl.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion Konstruktori

        #region Rukovaoci dogadjajima OpenGL kontrole

        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            m_world.Draw();
        }

        private void OpenGlControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // TODO 8 Interakcija sa korisnikom.
                case Keys.F2: this.Close(); break;
                case Keys.F: if (!animacija) { m_world.RotationX -= 4.0f; m_world.Resize(); } break;
                case Keys.R: if (!animacija) { m_world.RotationX += 4.0f; m_world.Resize(); } break;
                case Keys.G: if (!animacija) { m_world.RotationY -= 4.0f; m_world.Resize(); } break;
                case Keys.D: if (!animacija) { m_world.RotationY += 4.0f; m_world.Resize(); } break;
                case Keys.B:
                    animacija = true;
                    m_world.planePositionX = -1.0f;
                    m_world.planePositionY = 60.0f;
                    m_world.planePositionZ = 680.0f;
                    timerAvion.Enabled = true; break;
                case Keys.Add: if (!animacija) { m_world.SceneDistance -= 50.0f; m_world.Resize(); } break;
                case Keys.Subtract: if (!animacija) { m_world.SceneDistance += 50.0f; m_world.Resize(); } break;
                default: m_world.Resize(); break;
            }

            if (m_world.xRotationAngle < 2)
                m_world.xRotationAngle = 2;
            else if (m_world.xRotationAngle > 63)
                m_world.xRotationAngle = 63;

            openGlControl.Refresh();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Program.KeepRunning = true;
            this.Close();
        }

        // TODO 12 Animacija kretanja aviona.
        private void timerAvion_Tick(object sender, EventArgs e)
        {
            if (m_world.planePositionZ > 0)
            {
                m_world.planePositionZ -= 50;
            }
            else
            {
                if (m_world.planePositionZ > -700)
                {
                    m_world.planePositionZ -= 50;
                    m_world.planePositionY += 10;
                    m_world.planeRotationAngle -= 1.8f;
                    // Ukoliko zelimo da se zakrivi na desno prilikom polijetanja, staviti ovu drugu.
                    m_world.planeRotationX = 0.0f;
                    //m_world.planeRotationX = 1.0f;
                }
                else
                {
                    timerAvion.Enabled = false;
                    animacija = false;
                    m_world.planeRotationAngle = 0.0f;
                    m_world.planeRotationX = 0.0f;
                    m_world.planePositionX = -1.0f;
                    m_world.planePositionY = 60.0f;
                    m_world.planePositionZ = 680.0f;
                }

            }
            m_world.Resize();
            openGlControl.Refresh();
        }

        // TODO 12 Animacija paljenja/gasenja sijalica.
        private void timerSijalice_Tick(object sender, EventArgs e)
        {
            // TODO 7b Izbor intevala paljenja/gasenja sijalica.
            timerSijalice.Interval = (int)numericSInterval.Value * 1000;
            
            // Ukoliko je bila crna postavi na onu koja je trenutno aktivna.
            if (m_world.Color[0] == 0 && m_world.Color[1] == 0 && m_world.Color[2] == 0)
            {
                // TODO 7a Izbor boja sijalice.
                int[] colors = new int[3] { (int)numericRed.Value, (int)numericGreen.Value, (int)numericBlue.Value };
                m_world.Color = colors;
            }
            // Ukoliko nije postavi na  crnu.
            else
            {
                m_world.Color = new int[3] { 0, 0, 0 };
            }
            m_world.Resize();
            openGlControl.Refresh();
        }

      

        #endregion Rukovaoci dogadjajima OpenGL kontrole

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // TODO 7c Izbor faktora skaliranja.
            m_world.Sfactor = (float)numericSFactor.Value / 10;
        }

    }
}
