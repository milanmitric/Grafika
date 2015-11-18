// -----------------------------------------------------------------------
// <file>MainForm.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Demonstracija ucitavanja modela pomocu AssimpNet biblioteke i koriscenja u OpenGL-u.</summary>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assimp;
using System.IO;
using System.Reflection;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    public partial class MainForm : Form
    {
        #region Atributi

        /// <summary>
        ///	 Instanca OpenGL "sveta" - klase koja je zaduzena za iscrtavanje koriscenjem OpenGL-a.
        /// </summary>
        World m_world = null;

        /// <summary>
        /// Koristi se da bi se znalo da li je povecana ili smanjena vrednost kontrole.
        /// </summary>
        private decimal oldScale = 0;
        
        /// <summary>
        /// Koristi se da bi se znalo da li je povecana ili smanjena vrednost kontrole.
        /// </summary>
        private decimal oldSceneDistance = 0;

        /// <summary>
        /// Koristi se da bi se znalo da li je povecana ili smanjena vrednost kontrole.
        /// </summary>
        private decimal oldTranslate = 0;

        #endregion Atributi

        #region Konstruktori

        public MainForm()
        {
            // Inicijalizacija komponenti
            InitializeComponent();

            // Inicijalizacija OpenGL konteksta
            openglControl.InitializeContexts();

            // Kreiranje OpenGL sveta
            try
            {
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\Airplane"), "Plane.3DS", openglControl.Width, openglControl.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion Konstruktori

        #region Rukovaoci dogadjajima OpenGL kontrole

        /// <summary>
        /// Rukovalac dogadja izmene dimenzija OpenGL kontrole
        /// </summary>
        private void OpenGlControlResize(object sender, EventArgs e)
        {
            m_world.Height = openglControl.Height;
            m_world.Width = openglControl.Width;

            m_world.Resize();
        }

        /// <summary>
        /// Rukovalac dogadjaja iscrtavanja OpenGL kontrole
        /// </summary>
        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            // Iscrtaj svet
            m_world.Draw();
        }

        /// <summary>
        /// Rukovalac dogadjaja: obrada tastera nad formom
        /// </summary>
        private void OpenGlControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: m_world.RotationX -= 5.0f; break;
                case Keys.S: m_world.RotationX += 5.0f; break;
                case Keys.A: m_world.RotationY -= 5.0f; break;
                case Keys.D: m_world.RotationY += 5.0f; break;
                case Keys.Q: m_world.RotationZ += 5.0f; break;
                case Keys.E: m_world.RotationZ -= 5.0f; break;
                case Keys.Add: m_world.SceneDistance -= 7.0f; m_world.Resize(); break;
                case Keys.Subtract: m_world.SceneDistance += 7.0f; m_world.Resize(); break;
                case Keys.F10: this.Close(); break;
            }

            openglControl.Refresh();
        }

        

        /// <summary>
        /// Aktivira se na odredjeni interval definisan kao property same komponente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenGlTimerTick(object sender, EventArgs e)
        {
            m_world.Update();
            openglControl.Refresh();
        }

        /// <summary>
        /// Promena vrednosti komponente za translaciju aviona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumTranslateValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;
            if (num.Value > oldTranslate)
            {
                m_world.UpdateTranslateFactor(true);
            }
            else
            {
                m_world.UpdateTranslateFactor(false);
            }
            oldTranslate = num.Value;
            
            openglControl.Refresh();
        }

        /// <summary>
        /// Promena vrednosti komponente za skaliranje aviona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumScaleValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;

            if (num.Value > oldScale)
            {
                m_world.UpdateScale(true);
            }
            else
            {
                m_world.UpdateScale(false);
            }
            oldScale = num.Value;

            openglControl.Refresh();
        }

        /// <summary>
        /// Promenta vrednosti komponente za udaljenost scene od aviona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumSceneDistanceValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = (NumericUpDown)sender;

            if (num.Value > oldSceneDistance)
            {
                m_world.UpdateSceneDist(true);
            }
            else
            {
                m_world.UpdateSceneDist(false);
            }
            oldSceneDistance = num.Value;

            openglControl.Refresh();
        }

        #endregion Rukovaoci dogadjajima OpenGL kontrole
    }
}
