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
    class PlanetControl : GraphicsDeviceControl
    {
        private SpriteFont sf;
        private Sprite pSprite;
        private Planet planet;

        public Planet Planet 
        {
            get 
            { 
                return planet; 
            } 
            set 
            { 
                planet = value;
                pSprite.Scale = ChooseScaleFromTrait(planet.ScaleTrait);
            } 
        }

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            ContentStorageManager.Store<Texture2D>("Planet", GameControl.content.Load<Texture2D>("Planet"));
            ContentStorageManager.Store<SpriteFont>("PlayFont", GameControl.content.Load<SpriteFont>("Play"));

            pSprite = new Sprite(ContentStorageManager.Get<Texture2D>("Planet"));
            pSprite.CenterOriginOnTexture();
            pSprite.Position = StarSystemControl.orbitPoint;

            sf = ContentStorageManager.Get<SpriteFont>("PlayFont");

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
               //Do Stuff
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            if (Visible)
            {
                pSprite.Draw(GameControl.spriteBatch);

                DrawPlanetInfo(planet.ScaleTrait + " " + planet.PType + " Planet", new Vector2(32, 32));
                DrawPlanetInfo("Mineral " + planet.MineralTrait, new Vector2(32, 64));
                DrawPlanetInfo(planet.GravityTrait + " Gravity", new Vector2(32, 96));
                DrawPlanetInfo(planet.MiscTrait, new Vector2(32, 128));
                if (!string.IsNullOrEmpty(planet.RareTrait))
                {
                    DrawPlanetInfo(planet.RareTrait, new Vector2(32, 160));    
                }
            }
        }

        private void DrawPlanetInfo(string text, Vector2 position)
        {
            GameControl.spriteBatch.DrawString(sf, text, position, Color.LightBlue);
        }

        private float ChooseScaleFromTrait(string scaleTrait)
        {
            switch (planet.ScaleTrait)
            {
                case "Tiny":
                    {
                        return 0.40f;
                    }
                case "Small":
                    {
                        return 0.55f;
                    }
                case "Medium":
                    {
                        return 0.70f;
                    }
                case "Large":
                    {
                        return 0.85f;
                    }
                case "Huge":
                    {
                        return 1f;
                    }
                default:
                    return 1f;
            }
        }
    }
}
