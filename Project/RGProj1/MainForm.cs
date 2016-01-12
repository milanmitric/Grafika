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
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Model\\Avion"), "Airplane N061213.3DS", openGlControl.Width, openGlControl.Height);
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
                    m_world.planeRotationX = 1.0f;
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

        private void timerSijalice_Tick(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "5 sekundi": timerSijalice.Interval = 5000; break;
                case "4 sekunde": timerSijalice.Interval = 4000; break;
                case "3 sekunde": timerSijalice.Interval = 3000; break;
                case "2 sekunde": timerSijalice.Interval = 2000; break;
                case "1 sekund": timerSijalice.Interval = 1000; break;
                case "0.5 sekundi": timerSijalice.Interval = 500; break;
                case "0.1 sekundi": timerSijalice.Interval = 100; break;

            }
            if (m_world.boja == "crna")
                m_world.boja = comboBox1.Text;
            else m_world.boja = "crna";
            m_world.Resize();
            openGlControl.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_world.faktorS = comboBox3.Text;
        }

        #endregion Rukovaoci dogadjajima OpenGL kontrole

    }
}
