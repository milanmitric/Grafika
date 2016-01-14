// -----------------------------------------------------------------------
// <file>Box.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2012.</copyright>
// <author>Srdjan Mihic</author>
// <summary>Klasa koja enkapsulira OpenGL programski kod za iscrtavanje kvadra sa tezistem u koord.pocetku.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe
{
  using Tao.OpenGl;
    using RGProj1;

  /// <summary>
  ///  Klasa enkapsulira OpenGL kod za iscrtavanje kvadra.
  /// </summary>
  class Box : IDrawable
  {
     #region Atributi

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        float m_height;

        /// <summary>
        ///	 Sirina kvadra.
        /// </summary>
        float m_width;

        /// <summary>
        ///	 Dubina kvadra.
        /// </summary>
        float m_depth;

     #endregion Atributi

     #region Properties

        /// <summary>
        ///	 Visina kvadra.
        /// </summary>
        public float Height
        {
          get { return m_height; }
          set { m_height = value; }
        }

        /// <summary>
        ///	 Sirina kvadra.
        /// </summary>
        public float Width
        {
          get { return m_width; }
          set { m_width = value; }
        }

        /// <summary>
        ///	 Dubina kvadra.
        /// </summary>
        public float Depth
        {
          get { return m_depth; }
          set { m_depth = value; }
        }

     #endregion Properties

     #region Konstruktori

        /// <summary>
        ///		Konstruktor.
        /// </summary>
        public Box()
        {
        }

        /// <summary>
        ///		Konstruktor sa parametrima.
        /// </summary>
        /// <param name="width">Sirina kvadra.</param>
        /// <param name="height">Visina kvadra.</param>
        /// <param name="depth"></param>
        public Box(float width, float height, float depth)
        {
          this.m_width  = width;
          this.m_height = height;
          this.m_depth  = depth;
        }
    
     #endregion Konstruktori

     #region Metode

        public void Draw()
        {
          Gl.glBegin(Gl.GL_QUADS);

            // Zadnja
            //Gl.glColor3ub(112, 128, 144);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);

            // Desna
            //Gl.glColor3ub(0, 0, 0);
            Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, m_height / 2, m_depth / 2);
            Gl.glVertex3d(m_width / 2, -m_height / 2, m_depth / 2);

            // Prednja
           // Gl.glColor3ub(0, 0, 0);
            Gl.glVertex3d(m_width / 2, -m_height / 2, m_depth / 2);  
            Gl.glVertex3d(m_width / 2, m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, m_depth / 2);


            // Leva
           // Gl.glColor3ub(0, 0, 0);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);

            // Donja
            //Gl.glColor3ub(0, 0, 0);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, -m_height / 2, -m_depth / 2);
            Gl.glVertex3d(m_width / 2, -m_height / 2, m_depth / 2);
            Gl.glVertex3d(-m_width / 2, -m_height / 2, m_depth / 2);

            // Gornja
            //Gl.glColor3ub(0, 0, 0);
            
            Gl.glVertex3d(-m_width / 2, m_height / 2, -m_depth / 2);
            
            Gl.glVertex3d(-m_width / 2, m_height / 2, m_depth / 2);
            
            Gl.glVertex3d(m_width / 2, m_height / 2, m_depth / 2);
            
            Gl.glVertex3d(m_width / 2, m_height / 2, -m_depth / 2);

            Gl.glNormal3fv(Lighting.FindFaceNormal(m_width / 2, m_height / 2, m_depth / 2, m_width / 2, m_height / 2, -m_depth / 2, -m_width / 2, m_height / 2, -m_depth / 2));
            Gl.glNormal3fv(Lighting.FindFaceNormal(-m_width / 2, m_height / 2, -m_depth / 2, -m_width / 2, m_height / 2, m_depth / 2, m_width / 2, m_height / 2, m_depth / 2));

          Gl.glEnd();
        }

        public void SetSize(float width, float height, float depth)
        {
          m_depth = depth;
          m_height = height;
          m_width = width;

        }
     
     #endregion Metode
  }
}
