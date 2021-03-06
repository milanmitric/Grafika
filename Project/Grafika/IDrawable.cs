﻿// -----------------------------------------------------------------------
// <file>IDrawable.cs</file>
// <copyright>Grupa za Grafiku, Interakciju i Multimediju 2012.</copyright>
// <author>Srdjan Mihic</author>
// <summary>Demonstracija OpenGL i GLU primitiva.</summary>
// -----------------------------------------------------------------------
namespace RacunarskaGrafika.Vezbe
{
  /// <summary>
  /// Dozvoljava iscrtavanje objekata
  /// </summary>
  public interface IDrawable
  {
    /// <summary>
    /// Iscrtavanje pomocu OpenGL-a
    /// </summary>
    void Draw();
  }
}
