using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using System.Windows.Forms;
using Assimp;
using RacunarskaGrafika.Vezbe.AssimpNetSample;
using RacunarskaGrafika.Vezbe;
using System.Drawing;
using System.Drawing.Imaging;

namespace RGProj1
{
    class World : IDisposable
    {
        #region Primate members

        /// <summary>
        /// Udaljenost od scene.
        /// </summary>
        private float m_sceneDistance = 800.0f;
        /// <summary>
        /// Trenutna rotacija po y osi koja se vrsi preko kontrole.
        /// </summary>
        public float yRotationAngle = 0.0f;
        /// <summary>
        /// Trenutna rotacija po y osi koja se vrsi preko kontrole.
        /// </summary>
        public float xRotationAngle = 10.0f;
        /// <summary>
        /// Sirina viewporta.
        /// </summary>
        private int width;
        /// <summary>
        /// Visina viewporta.
        /// </summary>
        private int height;
        /// <summary>
        /// Assimpscene objekat iliti scena..
        /// </summary>
        private AssimpScene scene;
        /// <summary>
        /// Staza iliti pista za avion.
        /// </summary>
        private Box runway = null;
        /// <summary>
        /// Objekat za crtanje lampica ili sfera pored piste.
        /// </summary>
        private Glu.GLUquadric gluObject;
        /// <summary>
        /// Objekat za ispisivanje teksta.
        /// </summary>
        private BitmapFont bmpFont = null;
        /// <summary>
        /// Lista linija koje ide paralelno za pistom do kraja.
        /// </summary>
        private int firstLinesList;
        /// <summary>
        /// Lista linija koje idu poprijeko ispred aviona.
        /// </summary>
        private int secondLinesList;
        /// <summary>
        /// Enumeracija za teksture.
        /// </summary>
        public enum TextureObject { Groundwork = 0, Runway };
        /// <summary>
        /// Brojac za teksture.
        /// </summary>
        private readonly int textureCount = Enum.GetNames(typeof(TextureObject)).Length;
        /// <summary>
        /// Pomocna promjenljiva za teksture.
        /// </summary>
        Bitmap image;
        /// <summary>
        /// X koordinata aviona.
        /// </summary>
        public float planePositionX = -1.0f;
        /// <summary>
        /// Y koordinata aviona.
        /// </summary>
        public float planePositionY = 60.0f;
        /// <summary>
        /// Z koordinata aviona.
        /// </summary>
        public float planePositionZ = 680.0f;
        /// <summary>
        /// Ugao rotacije koji se koristi da bi se u animaciji prikazalo kako avion polijece.
        /// </summary>
        public float planeRotationAngle = 0.0f;
        /// <summary>
        /// Rotacija po X osi, koristi se kada avion polijece.
        /// </summary>
        public float planeRotationX = 0.0f;
        /// <summary>
        /// Rotacija po Y osi, posto avion polijece u jednom smjeru ona se nikada ne mijenja.
        /// </summary>
        public float planeRotationY = 0.0f;
        /// <summary>
        /// Rotacija po Y osi, posto avion polijece u jednom smjeru ona se nikada ne mijenja.
        /// </summary>
        public float planeRotationZ = 0.0f;
        /// <summary>
        /// Boja koja se bira iz forme.
        /// </summary>
        private int[] color = new int[3] { 128, 128, 128 };
        static int[] textures = null;
        //public string faktorS = "1";
        static string[] textureFiles = { "..//..//images//Seamless ground dirt texture.jpg", "..//..//images//asphalt_texture415.jpg" };
        /// <summary>
        /// Faktor skaliranja za sijalice.
        /// </summary>
        private float sFactor = 1;
        #endregion Atributi

        #region Properties

        public AssimpScene Scene
        {
            get { return scene; }
            set { scene = value; }
        }

        public float RotationY
        {
            get { return yRotationAngle; }
            set { yRotationAngle = value; }
        }

        public float RotationX
        {
            get { return xRotationAngle; }
            set { xRotationAngle = value; }
        }

        public float SceneDistance
        {
            get { return m_sceneDistance; }
            set { m_sceneDistance = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Javni getter i setter za faktor skaliranja.
        /// </summary>
        public float Sfactor
        {
            get { return sFactor; }
            set { sFactor = value; }
        }

        public int[] Color
        {
            get { return color; }
            set
            {
                color[0] = value[0];
                color[1] = value[1];
                color[2] = value[2];
            }
        }
        #endregion Properties

        #region Konstruktori

        public World(String scenePath, String sceneFileName, int width_, int height_)
        {
            this.scene = new AssimpScene(scenePath, sceneFileName);
            this.width = width_;
            this.height = height_;

            try
            {
                this.runway = new Box();
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL Box: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                bmpFont = new BitmapFont("Tahoma", 14, false, true, true, false);
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL fonta: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                textures = new int[textureCount];
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno kreiran niz identifikatora za teksture", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.Initialize();
            this.Resize();
        }

        ~World()
        {
            this.Dispose(false);
        }

        #endregion Konstruktori

        #region Metode

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance * 1.4f);
            Gl.glRotatef(xRotationAngle, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(yRotationAngle, 0.0f, 1.0f, 0.0f);

            // TODO 6 Pozicioniraj kameru.
            Glu.gluLookAt(-260.0f, 60.0f, -80.0f, -10.0f, 10.0f, 620.0f, 0.0f, 1.0f, 0.0f);

            Sadrzaj();
            Gl.glFlush();
        }

        private void Initialize()
        {
            Gl.glClearColor(0.5f, 0.0f, 0.0f, 1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_CULL_FACE);

            // TODO 1. Ukljucenje color tracking
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            // Na koje parametre materija se odnose pozivi glColor();
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE); 
            // Ukljucenje proracuna osvetljenja.
            Gl.glEnable(Gl.GL_LIGHTING);
            // pozicija svetlosti i boje komponenata
            float[] sourceLightAmbient = { 1f, 1f, 1f, 1.0f };
            float[] sourceLightDiffuse = { 0.6f, 0.6f, 0.6f, 1.0f };
            // Pridruzi komponente svetlosnom izvoru 0
            // TODO 2b postavi boju da bude bijela.
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, sourceLightAmbient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, sourceLightDiffuse);
            // Podesi parametre tackastog svetlosnog izvora
            // TODO 2a postavi reflektorski svjetlosni izvor.
            Gl.glLightf(Gl.GL_LIGHT0, Gl.GL_SPOT_CUTOFF, 30.0f);
            // Ukljuci svetlosni izvor
            Gl.glEnable(Gl.GL_LIGHT0);

            // TODO 3 postavi wrapping da bude repreat. Podesi filtere da koristi linearno filtriranje i nacin stapanja da bude modulate.
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            // texture enviroment, nacin stapanja tekture sa materijalom
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            // Predji u rezim rada sa 2D teksturama
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            
            Gl.glGenTextures(textureCount, textures);

            for (int i = 0; i < textureCount; ++i)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[i]);

                image = new Bitmap(textureFiles[i]);

                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                BitmapData imageData = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int)Gl.GL_RGBA8, image.Width, image.Height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, imageData.Scan0);

                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);

                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

                image.UnlockBits(imageData);
                image.Dispose();

            }

        }

        public void Resize()
        {
            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, (double)width / (double)height, 1.5, 3000);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // pozicioniranje svetla pre transformacija, kako bismo dobili stacionarni izvor svetlosti
            // TODO 2c postavi koordinate svjetla.
            float[] sourceLightPos = { 0, 650f, 1200f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, sourceLightPos);
        }

        protected virtual void Dispose(bool disposing)
        {
            scene.Dispose();
        }

        private void Sadrzaj()
        {
            Podloga();
            Staza();
            Linije();
            Sijalice();
            IscrtavanjeScene();
            Gl.glPopMatrix();
            Tekst();
        }

        private void Podloga()
        {
            Gl.glPushMatrix();
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[(int)TextureObject.Groundwork]);

            Gl.glMatrixMode(Gl.GL_TEXTURE);
            Gl.glPushMatrix();
            Gl.glScalef(10.0f, 10.0f, 1.0f);
            Gl.glMatrixMode(Gl.GL_TEXTURE);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(800.0f, 0.5f, -800.0f);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(-800.0f, 0.5f, -800.0f);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(-800.0f, 0.5f, 800.0f);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(800.0f, 0.5f, 800.0f);
            Gl.glNormal3fv(Lighting.FindFaceNormal(800 / 2, 0.5f / 2, 800 / 2, 0.5f / 2, 0.5f / 2, -800 / 2, -800 / 2, 0.5f / 2, -800 / 2));
            Gl.glNormal3fv(Lighting.FindFaceNormal(-800 / 2, 0.5f / 2, -800 / 2, -800f / 2, 0.5f / 2, 800 / 2, 800 / 2, 0.5f / 2, 800 / 2));

            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            // TODO 10 Stapanje tesksture sa materijalom GL_ADD.
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_ADD);
            Gl.glPopMatrix();
        }

        private void Staza()
        {

            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
            // TODO 4 Pridruzi pisti teksturu asfalta.
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[(int)TextureObject.Runway]);

            runway.SetSize(700, 1600, 15);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 10.0f, 0.0f);
            Gl.glRotatef(90, 1.0f, 0.0f, 0.0f);
            Gl.glNormal3fv(Lighting.FindFaceNormal(8 / 2, 0.5f / 2, 60 / 2, 8 / 2, 0.5f / 2, -60 / 2, -8 / 2, 0.5f / 2, -60 / 2));
            Gl.glNormal3fv(Lighting.FindFaceNormal(-8 / 2, 0.5f / 2, -60 / 2, -8 / 2, 0.5f / 2, 60 / 2, 8 / 2, 0.5f / 2, 60 / 2));
            runway.Draw();

            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_TEXTURE);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
        }

        private void Linije()
        {

            firstLinesList = Gl.glGenLists(1);
            Gl.glNewList(firstLinesList, Gl.GL_COMPILE);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(8.0f, 0.5f, -60.0f);
            Gl.glVertex3f(-8.0f, 0.5f, -60.0f);
            Gl.glVertex3f(-8.0f, 0.5f, 60.0f);
            Gl.glVertex3f(8.0f, 0.5f, 60.0f);
            
            Gl.glEnd();
            Gl.glEndList();

            secondLinesList = Gl.glGenLists(1);
            Gl.glNewList(secondLinesList, Gl.GL_COMPILE);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(11.0f, 0.5f, -110.0f);
            Gl.glVertex3f(-11.0f, 0.5f, -110.0f);
            Gl.glVertex3f(-11.0f, 0.5f, 110.0f);
            Gl.glVertex3f(11.0f, 0.5f, 110.0f);
            Gl.glEnd();
            Gl.glEndList();

            Gl.glPushMatrix();
            Gl.glColor3ub(255, 255, 255);
            Gl.glTranslatef(0.0f, 18.0f, -700.0f);
            Gl.glCallList(firstLinesList);
            Gl.glTranslatef(0.0f, 0.0f, 230.0f);
            Gl.glCallList(firstLinesList);
            Gl.glTranslatef(0.0f, 0.0f, 230.0f);
            Gl.glCallList(firstLinesList);
            Gl.glTranslatef(0.0f, 0.0f, 230.0f);
            Gl.glCallList(firstLinesList);
            Gl.glTranslatef(0.0f, 0.0f, 230.0f);
            Gl.glCallList(firstLinesList);
            Gl.glTranslatef(0.0f, 0.0f, 230.0f);
            Gl.glCallList(firstLinesList);

            Gl.glTranslatef(-150.0f, 0.0f, 220.0f);
            Gl.glCallList(secondLinesList);
            Gl.glTranslatef(45.0f, 0.0f, 0.0f);
            Gl.glCallList(secondLinesList);
            Gl.glTranslatef(45.0f, 0.0f, 0.0f);
            Gl.glCallList(secondLinesList);
            Gl.glTranslatef(120.0f, 0.0f, 0.0f);
            Gl.glCallList(secondLinesList);
            Gl.glTranslatef(45.0f, 0.0f, 0.0f);
            Gl.glCallList(secondLinesList);
            Gl.glTranslatef(45.0f, 0.0f, 0.0f);
            Gl.glCallList(secondLinesList);
            Gl.glPopMatrix();
        }

        private void Sijalice()
        {
            Gl.glPushMatrix();
            /*
            switch (boja)
            {
                case "zuta": Gl.glColor3ub(255, 255, 0); break;
                case "plava": Gl.glColor3ub(0, 0, 255); break;
                case "crvena": Gl.glColor3ub(255, 0, 0); break;
                case "bela": Gl.glColor3ub(255, 255, 255); break;
                case "zelena": Gl.glColor3ub(0, 255, 0); break;
                case "crna": Gl.glColor3ub(0, 0, 0); break;
            }*/
            Gl.glColor3f((float)color[0]/255, (float)color[1]/255, (float)color[2]/255);
            
            //sFaktor = float.Parse(faktorS, System.Globalization.CultureInfo.InvariantCulture);

            gluObject = Glu.gluNewQuadric();
            Glu.gluQuadricOrientation(gluObject, Glu.GLU_OUTSIDE);
            Gl.glScalef(sFactor, sFactor, sFactor);
            Gl.glTranslatef(-240f, 16.0f, 760.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(480.0f, 0.0f, 1520f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glTranslatef(0.0f, 0.0f, -117.0f);
            Glu.gluSphere(gluObject, 13.0f, 8, 8);
            Gl.glPopMatrix();
        }

        private void IscrtavanjeScene()
        {
            Gl.glTranslatef(planePositionX, planePositionY, planePositionZ);
            Gl.glScalef(0.11f, 0.11f, 0.11f);
            Gl.glRotatef(-2, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(180, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(planeRotationAngle, planeRotationX, planeRotationY, planeRotationZ);


            float[] lightPos = { -1, 20f, -1, 1.0f };
            float[] lightSmer = { 0.0f, -1.0f, 0.0f };
            float[] lightAmbient = { 0f, 1f, 0.0f, 1.0f };
            float[] lightDiffuse = { 0.6f, 0.6f, 0.6f, 1f };

            // TODO 9 tackasti izbor iznad aviona.
            // Pridruzi komponente svetlosnom izvoru 0
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, lightAmbient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, lightDiffuse);
            // Podesi parametre reflektorskog svetlosnog izvora
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, lightSmer);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 180f);
            // Ukljuci svetlosni izvor
            Gl.glEnable(Gl.GL_LIGHT1);
            // pozicioniranje svetla
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, lightPos);

            scene.Draw();


        }

        private void Tekst()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-width / 2.0, width / 2.0, -height / 2.0, height / 2.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glColor3ub(0, 191, 255);
            Gl.glRasterPos2d(width - 1190, height - 305);
            bmpFont.DrawText("Predmet: Racunarska grafika");
            Gl.glRasterPos2d(width - 1190, height - 325);
            bmpFont.DrawText("Sk.god: 2015/16");
            Gl.glRasterPos2d(width - 1190, height - 345);
            bmpFont.DrawText("Ime: Milan");
            Gl.glRasterPos2d(width - 1190, height - 365);
            bmpFont.DrawText("Prezime: Mitric");
            Gl.glRasterPos2d(width - 1190, height - 385);
            bmpFont.DrawText("Sifra zad: 6.2");
        }

        #endregion Metode

        #region IDisposable metode

        public void Dispose()
        {
            Glu.gluDeleteQuadric(gluObject);
            bmpFont.Dispose();
            Gl.glDeleteLists(firstLinesList, 1);
            Gl.glDeleteLists(secondLinesList, 1);
        }

        #endregion IDisposable metode

    }
}
