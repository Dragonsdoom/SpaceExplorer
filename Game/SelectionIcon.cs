using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoomLib;

namespace SpaceExplorerXNAWF
{
    /// <summary>
    /// The selection icon graphically indicates the currently selected star.
    /// </summary>
    public static class SelectionIcon
    {
        public static event EventHandler<EventArgs> RaiseStarSelectedEvent = delegate { };

        private static Sprite sprite;
        private static bool isGrowingInSize = true;
        public  static Star selectedStar;

        /// <summary>
        /// Prepares the selection icon to draw.
        /// </summary>
        public static void Initialize()
        {
            sprite = new Sprite(ContentStorageManager.Get<Texture2D>("SelectionDisc"));
            sprite.Origin = (sprite.GetTextureSize() / 2);
            sprite.Scale = 1f;
            sprite.Color = Color.White;
            ClearSelection();
        }

        public static void MakeSelection(Star star)
        {
            selectedStar = star;
            sprite.Position = star.Position;
            RaiseStarSelectedEvent(null, new EventArgs());  //Raise Star Selected Event
        }
        public static void MakeSelection(string name)
        {
            Star s = GalaxyGenerator.GetStarByName(name);
            if (s != null)
            {
                selectedStar = s;
                sprite.Position = s.Position;
            }
            RaiseStarSelectedEvent(null, new EventArgs());  //Raise Star Selected Event
        }

        public static void ClearSelection()
        {
            sprite.Position = new Vector2(-60, -60);
        }

        public static void Draw(SpriteBatch sb)
        {
            // Pulse animation
            if (isGrowingInSize)
            {
                sprite.Scale *= 1.03f;
                if (sprite.Scale > 1.5f)
                {
                    isGrowingInSize = false;
                }
            }
            else
            {
                sprite.Scale *= 0.97f;
                if (sprite.Scale < 0.75f)
                {
                    isGrowingInSize = true;
                }
            }

            sprite.Draw(sb);
        }
    }
}
