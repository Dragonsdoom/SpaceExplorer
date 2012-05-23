#region File Description
//-----------------------------------------------------------------------------
// StarSystemControl.cs
// 12/28/2011 9:11 AM
// Dragonsdoom
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using DoomLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XKeys = Microsoft.Xna.Framework.Input.Keys;
using Point = System.Drawing.Point;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
#endregion

namespace SpaceExplorerXNAWF
{
    /// <summary>
    /// This control displays the system view.
    /// </summary>
    class StarSystemControl : GraphicsDeviceControl
    {
        Sprite starSystemStar;
        Star currentStar;
        public static Vector2 orbitPoint = Vector2.Zero;
        public PlanetControl planetControl;

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            ContentStorageManager.Store<Texture2D>("StarSystemStar", GameControl.content.Load<Texture2D>("StarSystemStar"));
            starSystemStar = new Sprite(ContentStorageManager.Get<Texture2D>("StarSystemStar"));
            starSystemStar.Origin = (starSystemStar.GetTextureSize() / 2);
            starSystemStar.Position = new Vector2(this.Size.Width / 2, this.Size.Height / 2);
            orbitPoint = starSystemStar.Position;

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
                foreach (OrbitalBody ob in currentStar.OrbitalBodies)
                {
                    ob.DrawBody.UpdatePosition(orbitPoint);
                }
                CheckPlanetData();
            }
        }

        /// <summary>
        /// Handles player selection of stars.
        /// </summary>
        private void CheckPlanetData()
        {
            if (MouseManager.MState.LeftButton == ButtonState.Released
                        && MouseManager.oldMState.LeftButton == ButtonState.Pressed)
            {
                foreach (OrbitalBody ob in currentStar.OrbitalBodies)
                {
                    //Translates position from screen coordinates to client coordinates 
                    //from Vector2 to Point to Vector2.
                    Point p = PointToClient(new Point(MouseManager.MState.X, MouseManager.MState.Y));

                    //Compares distance for selection radius.
                    if (Vector2.DistanceSquared(ob.DrawBody.Position, new Vector2(p.X, p.Y)) < 1200) // I'm just guessing here, but it works fine.
                    {
                        if (!ob.playerHasVisited)
                        {
                            ob.playerHasVisited = true;
                            ob.DrawBody.SwapToDiscoveredTexture();
                        }
                        planetControl.Visible = true;
                        this.Visible = false;
                        planetControl.Planet = (Planet)ob;
                        break;
                    }
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
                starSystemStar.Draw(GameControl.spriteBatch);

                foreach (OrbitalBody ob in currentStar.OrbitalBodies)
                {
                    if (!ob.playerHasVisited)
                    {
                        ob.DrawBody.Color = Color.LightGray;
                    }
                    ob.DrawBody.Draw();
                }
            }
        }

        public Star GetCurrentStar()
        {
            return currentStar;
        }

        public void ClearCurrentStar()
        {
            currentStar = null;
        }

        public void SetCurrentStar(ref Star value)
        {
            currentStar = value;
            starSystemStar.Color = currentStar.Color;
        }
    }
}
