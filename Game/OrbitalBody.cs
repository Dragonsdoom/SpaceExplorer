using System;
using System.Collections.Generic;
using System.Text;
using DoomLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceExplorerXNAWF
{
    public abstract class OrbitalBody
    {
        protected string pType;
        protected string mineralTrait;
        protected string gravityTrait;
        protected string scaleTrait;
        protected string miscTrait;
        protected string rareTrait;

        public string PType         { get { return pType; } }
        public string MineralTrait  { get { return mineralTrait; } }
        public string GravityTrait  { get { return gravityTrait; } }
        public string ScaleTrait    { get { return scaleTrait; } }
        public string MiscTrait     { get { return miscTrait; } }
        public string RareTrait     { get { return rareTrait; } }

        protected OrbitalBodyDrawData drawBody;
        public OrbitalBodyDrawData DrawBody { get { return drawBody; } }

        public bool playerHasVisited = false;
    }

    public class OrbitalBodyDrawData
    {
        Sprite s;
        float radius, angularVelocity;
        public float angle;
        Vector2 orbitPoint;
        Vector2 position;
        Texture2D texture;

        public Vector2 Position { get { return position; } private set { position = value; s.Position = position; } }
        public Color Color { get { return s.Color; } set { s.Color = value; } }

        public OrbitalBodyDrawData(Texture2D texture, float radius)
        {
            this.texture = texture;
            Random r = new Random();
            s = new Sprite(ContentStorageManager.Get<Texture2D>("PlanetUnknown"));
            s.CenterOriginOnTexture();
            this.radius = radius;
            angle = MathHelper.ToRadians(GameControl.GetRandomNumber(360));
            angularVelocity = r.Next(4, 8) * 0.001f;
        }

        public void Draw()
        {
            s.Draw(GameControl.spriteBatch);
        }

        /// <summary>
        /// When a planet is visited for the first time, call this method to change the texture in the star system.
        /// </summary>
        public void SwapToDiscoveredTexture()
        {
            s = new Sprite(Position, texture);
            s.CenterOriginOnTexture();
        }

        public void UpdatePosition(Vector2 orbitPoint)
        {
            this.orbitPoint = orbitPoint;
            float x = orbitPoint.X + (float)(radius * Math.Cos(angle));
            float y = orbitPoint.Y + (float)(radius * Math.Sin(angle) * 0.65f); // Visual eccentricity
            Position = new Vector2(x, y);
            angle += angularVelocity;
        }
    }
}
