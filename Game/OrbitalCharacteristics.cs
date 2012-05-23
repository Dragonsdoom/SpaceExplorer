using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceExplorerXNAWF
{
    static class OrbitalCharacteristics
    {
        /// <summary>
        /// PlanetTypes contains all the different types of possible planet.
        /// </summary>
        public static readonly string[] PlanetTypes =
        {
            // The planet types are specifically organized to respond 
            // interestingly to a bell curve distribution of random probability.
            "Molten", "Ice", "Aquan", "Desert", "Terran", "Barren", "Jungle", "Plasma", "Gaia"
        };

        public static readonly string[] MineralTraits =
        {
            "Ultra-Rich", "Rich", "Average",
            "Poor", "Ultra-Poor"
        };

        public static readonly string[] GravityTraits =
        {
            "Low", "Normal", "High"
        };

        public static readonly string[] ScaleTraits =
        {
            "Tiny", "Small", "Medium",
            "Large", "Huge"
        };

        public static readonly string[] MiscTraits =
        {
            "Toxic", "Super Toxic", "Natives",
            "Treasure", "Fuel Dump",
            "Remains"
        };

        public static readonly string[] RareTraits =
        {
            "Ancient Artifacts", "Super Caverns",
            "Dimensional Portal", "Splinter Colony",
            "Floating Islands", "Doomsday Device"
        };
    }
}
