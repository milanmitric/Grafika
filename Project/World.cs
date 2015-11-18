// -----------------------------------------------------------------------
// <file>World.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2013.</copyright>
// <author>Zoran Milicevic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    using System;
    using Tao.OpenGl;
    using Assimp;
    using System.IO;
    using System.Reflection;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    /// <summary>
    ///  Klasa enkapsulira OpenGL kod i omogucava njegovo iscrtavanje i azuriranje.
    /// </summary>
    public class World : IDisposable
    {
        #region Atributi

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        private AssimpScene m_scene;

        /// <summary>
        /// Identifikator fonta.
        /// </summary>
        private BitmapFont m_font = null; 

        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        private float m_sceneDistance = 130;

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_width;

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_height;

        /// <summary>
        /// Kolicina translacije za pomeranje aviona po pisti.
        /// </summary>
        private int m_translate = 0;

        /// <summary>
        /// Znak da li treba poceti povecavati ili smanjivati translaciju modela tj da li ga treba pomerati napred ili nazad.
        /// </summary>
        private int m_translate_sing = 1;

        /// <summary>
        /// Kolicina za koju ce se avion pomerati po ekranu.
        /// </summary>
        private int m_translate_factor = 100;

        /// <summary>
        /// Maksimalna kolicina translacije da avion ne sidje sa staze.
        /// </summary>
        private float m_translate_max = 23000;

        /// <summary>
        /// Kolicina skaliranja modela.
        /// </summary>
        private float m_scale = 1f;
        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        private float m_xRotation = 0.0f;

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        private float m_yRotation = 0.0f;

        /// <summary>
        /// Ugao rotacije sve oko Z ose.
        /// </summary>
        private float m_zRotation = 0.0f;

        //private OutlineFont m_font = null;

        private String[] m_message= { "Predmet: Racunarska grafika","Sk.god: 2015/16.", "Ime: Milan","Prezime: Mitric" ,"Sifra zad: 6.2"};

        #endregion Atributi

        #region Properties

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        public AssimpScene Scene
        {
            get { return m_scene; }
            set { m_scene = value; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko X ose.
        /// </summary>
        public float RotationX
        {
            get { return m_xRotation; }
            set { m_xRotation = value; }
        }

        /// <summary>
        ///	 Ugao rotacije sveta oko Y ose.
        /// </summary>
        public float RotationY
        {
            get { return m_yRotation; }
            set { m_yRotation = value; }
        }

        /// <summary>
        /// Ugao rotacije sveta oko Z ose.
        /// </summary>
        public float RotationZ
        {
            get { return m_zRotation; }
            set { m_zRotation = value; }
        }
        /// <summary>
        ///	 Udaljenost scene od kamere.
        /// </summary>
        public float SceneDistance
        {
            get { return m_sceneDistance; }
            set { m_sceneDistance = value; }
        }

        /// <summary>
        ///	 Sirina OpenGL kontrole u pikselima.
        /// </summary>
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        ///	 Visina OpenGL kontrole u pikselima.
        /// </summary>
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        #endregion Properties

        #region Konstruktori

        /// <summary>
        ///  Konstruktor klase World.
        /// </summary>
        public World(String scenePath, String sceneFileName, int width, int height)
        {
            this.m_scene = new AssimpScene(scenePath, sceneFileName);
            this.m_width = width;
            this.m_height = height;

            try
            {
                m_font = new BitmapFont("Tahoma", 14, false, true, true, false);
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL fonta", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Initialize();  // Korisnicka inicijalizacija OpenGL parametara

            this.Resize();      // Podesi projekciju i viewport
        }

        /// <summary>
        ///  Destruktor klase World.
        /// </summary>
        ~World()
        {
            this.Dispose(false);
        }

        #endregion Konstruktori

        #region Metode

        /// <summary>
        ///  Iscrtavanje OpenGL kontrole.
        /// </summary>
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

      
            Gl.glMatrixMode(Gl.GL_PROJECTION);      // selektuj Projection Matrix
            Gl.glLoadIdentity();
            Gl.glOrtho(-140, 150, -350, 200, -1.0, 1.0);
            Gl.glPushMatrix();
            Gl.glColor3f(0f, 0f, 1f);

            // Nacrtaj tekst.
            Gl.glRasterPos2d(-0.5 * m_font.CalculateTextWidth(m_message[0])  - 10, 180);
            m_font.DrawText(m_message[0]);
            Gl.glRasterPos2d(-0.5 * m_font.CalculateTextWidth(m_message[1]) - 60, 150);
            m_font.DrawText(m_message[1]);
            Gl.glRasterPos2d(-0.5 * m_font.CalculateTextWidth(m_message[2]) - 87, 120);
            m_font.DrawText(m_message[2]);
            Gl.glRasterPos2d(-0.5 * m_font.CalculateTextWidth(m_message[3]) - 71, 90);
            m_font.DrawText(m_message[3]);
            Gl.glRasterPos2d(-0.5 * m_font.CalculateTextWidth(m_message[4]) - 77, 60);
            m_font.DrawText(m_message[4]);


            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_PROJECTION);      // selektuj Projection Matrix
            Gl.glLoadIdentity();
            Glu.gluPerspective(60.0, (double)m_width / (double)m_height, 1.5, 20000.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);      // selektuj MODELVIEW Matrix
            Gl.glLoadIdentity();



            // Transformacije koordinatnog sistema da stoji kao na pocetku.
            Gl.glPushMatrix();
            Gl.glClearColor(0.5f, 0.8f, 0.9f, 1.0f);
            Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance);
            Gl.glRotatef(m_xRotation, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(m_yRotation, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(m_zRotation, 0.0f, 0.0f, 1.0f);

            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance);
                Gl.glRotatef(90f, 1f, 0f, 0f);
                Gl.glRotatef(90f, 0f, 1f, 0f);
                Gl.glTranslatef(-130f, 0f, 0f);

                    // Transformacije i iscrtavanje podloge.
                    Gl.glPushMatrix();
                    Gl.glRotatef(-90f, 1f, 0f, 0f);
                    Gl.glTranslatef(0f, 0f, 48f);
                    Gl.glTranslatef(130, 0f, 0f);
                    Gl.glColor3f(0f, 1f, 0f);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex3f((float)m_width / 5f, (float)m_height/5f , -60f);
                    Gl.glVertex3f(-(float)m_width / 5f, (float)m_height/5f, -60f);
                    Gl.glVertex3f(-(float)m_width / 5f, -(float)m_height/5f , -60f);
                    Gl.glVertex3f((float)m_width / 5f, -(float)m_height/5f, -60f);
                    Gl.glEnd();
                    Gl.glPopMatrix();

                    // Transformacije i iscrtavanje piste pomocu Box klase.
                    Gl.glPushMatrix();
                    Gl.glColor3f(0f, 0f, 1f);
                    Gl.glTranslatef(0f,-5f, 0f);
                    Gl.glTranslatef(130, 0f, 0f);
                    Gl.glRotatef(90, 1f, 0f, 0f);
                    Box box = new Box(300, 90, 3);
                    box.Draw();
                    Gl.glPopMatrix();

                    // Zuta boja
                    Gl.glColor3f(1f, 1f, 0f);

                    // Iscrtavanje jedne strane sijalica.
                    for (int i = 0; i < 14; i++)
                    {
                        // Instanciraj novi gluObject.
                        Glu.GLUquadric gluObject = Glu.gluNewQuadric();

                        Gl.glPushMatrix();
                        // Pomeri za odredjenu udaljenost.
                        Gl.glTranslatef(i * 20f, -5f, -50f);
                        // Podesi parametre.
                        Glu.gluQuadricNormals(gluObject, Glu.GLU_SMOOTH);
                        // Iscrtaj.
                        Glu.gluSphere(gluObject, 4f, 128, 128);
                        // Obrisi.
                        Glu.gluDeleteQuadric(gluObject);
                        Gl.glPopMatrix();
                    }

                    // Iscrtavanje druge strane sijalica.
                    for (int i = 0; i < 14; i++)
                    {
                        // Instanciraj novi gluObject.
                        Glu.GLUquadric gluObject = Glu.gluNewQuadric();

                        Gl.glPushMatrix();
                        Gl.glTranslatef(i * 20f, -5f, 50f);
                        // Podesi parametre.
                        Glu.gluQuadricNormals(gluObject, Glu.GLU_SMOOTH);
                        // Iscrtaj.
                        Glu.gluSphere(gluObject, 4f, 128, 128);
                        // Obrisi.
                        Glu.gluDeleteQuadric(gluObject);
                        Gl.glPopMatrix();
                    }
                

                
                    // Iscrtavanje modela
                    Gl.glPushMatrix();
                    Gl.glScalef(m_scale * 0.01f, m_scale * 0.01f, m_scale * 0.01f);
                    Gl.glTranslatef(m_translate, 0f, 0f);
                    m_scene.Draw();
                    Gl.glPopMatrix();
                Gl.glPopMatrix();
            Gl.glPopMatrix();
            

            // Oznaci kraj iscrtavanja
            Gl.glFlush();
        }

        /// <summary>
        ///  Korisnicka inicijalizacija i podesavanje OpenGL parametara.
        /// </summary>
        private void Initialize()
        {
            // Boja pozadine je svetlo plava.
            Gl.glClearColor(0.5f,0.8f,0.9f,1.0f);
            // Ukljuciti testiranje dubine.
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // Ukljuciti sakrivanje nevidljivih povrsina.
            Gl.glEnable(Gl.GL_CULL_FACE);
        }

        /// <summary>
        /// Podesava viewport i projekciju za OpenGL kontrolu.
        /// </summary>
        public void Resize()
        {
            
            Gl.glViewport(0, 0, m_width, m_height); // kreiraj viewport po celom prozoru
            Gl.glMatrixMode(Gl.GL_PROJECTION);      // selektuj Projection Matrix
            Gl.glLoadIdentity();			        // resetuj Projection Matrix
            
            Glu.gluPerspective(60.0, (double)m_width / (double)m_height, 1.5, 20000.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);   // selektuj ModelView Matrix
            Gl.glLoadIdentity();                // resetuj ModelView Matrix

        }

        /// <summary>
        /// Sluzi za povecavanje vrednosti translacije modela.
        /// </summary>
        internal void Update()
        {
            // Translacija
            m_translate += m_translate_sing * m_translate_factor;
            if (m_translate > m_translate_max)
            {
                m_translate_sing = -1;
            }
            else if (m_translate < 0)
            {
                m_translate = 0;
                m_translate_sing = 1;
            }
        }

        /// <summary>
        /// Aktivira je klik na komponentu GUI-a.
        /// U zavisnosti od toga da li je pritisnut up ili down skalira objekat na veci ili manji respektivno.
        /// </summary>
        /// <param name="upOrDown">Indikator koji govori da li je UP - true ili DOWN - false.</param>
        internal void UpdateScale(bool upOrDown)
        {
            if (upOrDown)
            {
                m_scale += 0.05f;
                m_translate_max *= 0.96f;
            }
            else
            {
                m_scale -= 0.05f;
                m_translate_max *= 1.06f;
            }
        }

        /// <summary>
        /// Aktivira je klik na komponentu GUI-a.
        /// U zavisnosti od toga da li je pritisnut up ili down postavlja se scene distance na veci ili manji respektivno.
        /// </summary>
        /// <param name="upOrDown">Indikator koji govori da li je UP - true ili DOWN - false.</param>
        internal void UpdateSceneDist(bool upOrDown)
        {
            if (upOrDown)
            {
                m_sceneDistance += 7;
            }
            else
            {
                m_sceneDistance -= 7;
            }

        }

        /// <summary>
        /// Aktivira je klik na komponentu GUI-a.
        /// U zavisnosti od toga da li je pritisnut up ili down translira objekat na gore ili dole respektivno.
        /// U sustini vrsi pomeranje aviona po pisti.
        /// </summary>
        /// <param name="upOrDown">Indikator koji govori da li je UP - true ili DOWN - false.</param>
        internal void UpdateTranslateFactor(bool upOrDown)
        {
            if (upOrDown)
            {
                m_translate_factor += 2;
            }
            else
            {
                m_translate_factor -= 2;
            }

        }

        /// <summary>
        ///  Implementacija IDisposable interfejsa.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Oslodi managed resurse
            }

            // Oslobodi unmanaged resurse
            m_scene.Dispose();
            m_font.Dispose();

        }

        #endregion Metode

        #region IDisposable metode

        /// <summary>
        ///  Dispose metoda.
        /// </summary>
        public void Dispose()
        {
            
            
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable metode


    }
}
