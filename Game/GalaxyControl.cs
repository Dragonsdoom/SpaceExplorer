#region File Description
//-----------------------------------------------------------------------------
// GalaxyControl.cs
// Dragonsdoom
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using DoomLib;
using System.Collections.Generic;
using XKeys = Microsoft.Xna.Framework.Input.Keys;
using Point = System.Drawing.Point;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
#endregion

namespace SpaceExplorerXNAWF
{
    /// <summary>
    /// This control displays the galaxy view.
    /// </summary>
    class GalaxyControl : GraphicsDeviceControl
    {
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            ContentStorageManager.Store<Texture2D>("Star", GameControl.content.Load<Texture2D>("Star"));
            ContentStorageManager.Store<Texture2D>("SelectionDisc", GameControl.content.Load<Texture2D>("SelectionDisc"));
            ContentStorageManager.Store<Texture2D>("Planet", GameControl.content.Load<Texture2D>("PlanetSmall"));
            ContentStorageManager.Store<Texture2D>("PlanetUnknown", GameControl.content.Load<Texture2D>("PlanetSmallUnknown"));
            SelectionIcon.Initialize();

            // Hook the game think event to give us a place to do step by step calculations.
            GameControl.RaiseThinkEvent += delegate { Think(); };

            // Hook the game draw event to constantly redraw our animation.
            GameControl.RaiseDrawEvent += delegate { Draw(); };
        }

        /// <summary>
        /// The think method is used to perform regular game calculations.
        /// This method keeps track of time and updates 60 times per second.
        /// </summary>
        public void Think()
        {
            if (Visible)
            {
                CheckSelectedStar();
            }
        }

        /// <summary>
        /// Handles player selection of stars.
        /// </summary>
        private void CheckSelectedStar()
        {
            if (MouseManager.MState.LeftButton == ButtonState.Released
                        && MouseManager.oldMState.LeftButton == ButtonState.Pressed)
            {
                foreach (Star s in GalaxyGenerator.galaxyMap)
                {
                    if (s != null)
                    {
                        //Translates position from screen coordinates to client coordinates 
                        //from Vector2 to Point to Vector2.
                        Point p = PointToClient(new Point(MouseManager.MState.X, MouseManager.MState.Y));

                        //Compares distance for selection radius.
                        if (Vector2.DistanceSquared(s.Position, new Vector2(p.X, p.Y)) < 300) // I'm just guessing here, but it works fine.
                        {
                            SelectionIcon.MakeSelection(s);
                            break;
                        }
                    }
                    else break;
                }
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            if (Visible)
            {
                SelectionIcon.Draw(GameControl.spriteBatch);
                GalaxyGenerator.Draw(GameControl.spriteBatch);
            }
        }

        public void GenerateNewGalaxy()
        {
            GalaxyGenerator.GenerateGalaxy();
        }

        public void GenerateNewColors()
        {
            GalaxyGenerator.ColorStars();
        }

        public List<string> GetStarNames()
        {
            return GalaxyGenerator.GetStarNames();
        }
    }
}
