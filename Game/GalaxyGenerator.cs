using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoomLib;

namespace SpaceExplorerXNAWF
{
    struct StarColors
    {
        public static Color[] color = 
        {
            Color.Red,      Color.Green, 
            Color.Yellow,   Color.Blue,
            Color.Orange,   Color.Purple,                   
        };
    }

    public static class GalaxyGenerator
    {
        private static Rectangle plotArea = new Rectangle(20, 20, 980, 780);
        private const int MAX_STARS = 200;
        public static Star[] galaxyMap = new Star[MAX_STARS];
        private static NPack.MersenneTwister mt = new NPack.MersenneTwister();

        public static void GenerateGalaxy()
        {
            StarNames.ResetUsedNames();
            SelectionIcon.ClearSelection();
            for (int i = 0; i < MAX_STARS; i++)
            {
                GenerateStar(i);
            }
            MoveCloseStars();
            ColorStars();
        }

        /// <summary>
        /// This method generates a star with a position based on the Mersenne Twister algorithm.
        /// </summary>
        private static void GenerateStar(int index)
        {
            Vector2 position = new Vector2(mt.Next(plotArea.X, plotArea.Width), mt.Next(plotArea.Y, plotArea.Height));

            galaxyMap[index] = new Star();
            galaxyMap[index].Position = position;
        }

        /// <summary>
        /// This method uses GenerateStarPosition() on each star in the galaxy to remove overlapping stars.
        /// </summary>
        private static void MoveCloseStars()
        {
            for (int i = 0; i < MAX_STARS; i++)
            {
                galaxyMap[i].Position = GenerateStarPosition();
            }
        }

        /// <summary>
        /// This method generates a valid position for a star. This is a recursive function.
        /// </summary>
        /// <returns>position</returns>
        private static Vector2 GenerateStarPosition()
        {
            Vector2 position = new Vector2(mt.Next(plotArea.X, plotArea.Width),     //  generate position
                mt.Next(plotArea.Y, plotArea.Height));

            for (int i = 0; i < MAX_STARS; i++)                                     //  check against other positions
            {
                if (Vector2.Distance(position, galaxyMap[i].Position) < 25)         //  if the new position is too close
                {
                    position = new Vector2(mt.Next(plotArea.X, plotArea.Width),     //  set new position
                        mt.Next(plotArea.Y, plotArea.Height));

                    return GenerateStarPosition();                                  //  recursively call this method to check 
                    //  again now that we have moved positions
                }
            }
            return position;
        }

        /// <summary>
        /// This method generates orbitals for a star when called.
        /// </summary>
        public static List<OrbitalBody> GenerateSolarSystem(int totalOrbitals, Color starColor)
        {
            List<OrbitalBodyDrawData> oBDrawData = new List<OrbitalBodyDrawData>(totalOrbitals);
            oBDrawData = GenerateOrbitalDrawData(totalOrbitals);

            List<OrbitalBody> retList = new List<OrbitalBody>();
            for (int i = 0; i < totalOrbitals; i++)
            {
                retList.Add(new Planet(starColor, oBDrawData[i]));
            }

            return retList;
        }

        /// <summary>
        /// Orbitals are complex enough objects that their draw data is organized in a seperate class.
        /// This method builds a list of OrbitalBodyDrawData to be combined with the orbitals themselves.
        /// </summary>
        public static List<OrbitalBodyDrawData> GenerateOrbitalDrawData(int totalOrbitals)
        {
            List<OrbitalBodyDrawData> retList = new List<OrbitalBodyDrawData>(totalOrbitals);
            int mult = 140;
            for (int i = 0; i < totalOrbitals; i++)
            {
                retList.Add(new OrbitalBodyDrawData(ContentStorageManager.Get<Texture2D>("Planet"),
                    (i + 1) * mult));
                mult -= 20;
            }

            if (retList.Count > 1)
            {
                SpacePlanetsApart(ref retList);
            }

            return retList;
        }

        /// <summary>
        /// This method adjusts each planet's relative angle 
        /// so that the planets do not clip through each other.
        /// </summary>
        private static void SpacePlanetsApart(ref List<OrbitalBodyDrawData> oBDrawData)
        {
            float acceptableAngularDistance = 0.25f;
            for (int i = 0; i < oBDrawData.Count; i++)
            {
                for (int j = 0; j < oBDrawData.Count; j++)
                {
                    if (i != j)
                    {
                        if ((oBDrawData[i].angle > (oBDrawData[j].angle - acceptableAngularDistance)) &&
                            (oBDrawData[i].angle < (oBDrawData[j].angle + acceptableAngularDistance)))
                        {
                            oBDrawData[i].angle += acceptableAngularDistance;
                            i = 0;
                            j = 0;
                        }
                    }
                }
            }
        }

        public static void ColorStars()
        {
            Random rand = new Random();
            foreach (Star s in galaxyMap)
            {
                if (s != null)
                {
                    s.Color = StarColors.color[rand.Next(6)];
                }
            }
        }

        /// <summary>
        /// Returns the names of all stars that currently exist.
        /// </summary>
        public static List<string> GetStarNames()
        {
            List<string> names = new List<string>();
            foreach (Star s in galaxyMap)
            {
                names.Add(s.Name);
            }

            return names;
        }

        /// <summary>
        /// Finds and returns a star by name. 
        /// Returns null if no star with that name is found.
        /// </summary>
        public static Star GetStarByName(string name)
        {
            foreach (Star s in galaxyMap)
            {
                if (s.Name == name)
                {
                    return s;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds and returns the star closest to the point given.
        /// It is unlikely that this method is necessary.
        /// </summary>
        public static Star GetStarByPosition(Vector2 position)
        {
            Star closestStar = galaxyMap[0];
            foreach (Star s in galaxyMap)
            {
                if (Vector2.DistanceSquared(s.Position, position) <
                    Vector2.DistanceSquared(closestStar.Position, position))
                {
                    closestStar = s;
                }
            }

            return closestStar;
        }

        /// <summary>
        /// Draws each star.
        /// </summary>
        public static void Draw(SpriteBatch sb)
        {
            foreach (Star s in galaxyMap)
            {
                if (s != null)
                {
                    s.Draw(sb);
                }
            }
        }
    }
}
