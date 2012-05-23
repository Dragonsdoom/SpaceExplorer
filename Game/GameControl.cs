#region File Description
//-----------------------------------------------------------------------------
// GameControl.cs
// Dragonsdoom
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DoomLib;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XKeys = Microsoft.Xna.Framework.Input.Keys;
using Microsoft.Xna.Framework;
#endregion

namespace SpaceExplorerXNAWF
{
    /// <summary>
    /// This control acts as the base game class.
    /// </summary>
    class GameControl : GraphicsDeviceControl
    {
        public static SpriteBatch spriteBatch;
        public static ContentManager content;
        public static event EventHandler<EventArgs> RaiseThinkEvent = delegate { };
        public static event EventHandler<EventArgs> RaiseDrawEvent = delegate { };
        Stopwatch sw = new Stopwatch();

        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            sw.Start(); // Begins the countdown for the think method.

            content = new ContentManager(Services, "Content");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Hook the idle event to give us a place to do step by step calculations.
            Application.Idle += delegate { Think(); };

            // Hook the idle event to constantly redraw our animation.
            Application.Idle += delegate { Invalidate(); };
        }

        /// <summary>
        /// The think method is used to perform regular game calculations.
        /// This method keeps track of time and updates 60 times per second.
        /// </summary>
        public void Think()
        {
            // Gives us a regular interval of once every 1/60th of a second for our think method.
            if (sw.Elapsed >= System.TimeSpan.FromSeconds(0.0166666667)) // 0.0166666667 == 1/60th of a second.
            {
                sw.Reset();
                sw.Start();

                MouseManager.Update();
                KeyboardManager.Update();

                // Check to see if we need to close
                if (KeyboardManager.keyState.IsKeyDown(XKeys.Escape))
                {
                    Application.Exit();
                }

                RaiseThinkEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None);
            RaiseDrawEvent(this, new EventArgs());
            spriteBatch.End();
        }

        /// <summary>
        /// VLAD Wrote this handy slice of randomness.
        /// http://blog.codeeffects.com/Article/Generate-Random-Numbers-And-Strings-C-Sharp
        /// </summary>
        /// <param name="maxNumber">Must be greater than one</param>
        /// <returns></returns>
        public static int GetRandomNumber(int maxNumber)
        {
            if (maxNumber < 1)
                throw new System.Exception("The maxNumber value should be greater than 1");
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            int seed = (b[0] & 0x7f) << 24 | b[1] << 16 | b[2] << 8 | b[3];
            System.Random r = new System.Random(seed);
            return r.Next(1, maxNumber);
        }
    }
}
