using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoomLib;

namespace SpaceExplorerXNAWF
{
    /// <summary>
    /// This class represents an individual star. It contains data about its name, sprite, and orbital bodies.
    /// </summary>
    public class Star
    {
        private int totalOrbitalBodies;
        private List<OrbitalBody> orbitalBodies = new List<OrbitalBody>();
        private List<OrbitalBodyDrawData> orbitalDrawData = new List<OrbitalBodyDrawData>();
        private Sprite sprite;
        private string name;

        public List<OrbitalBody> OrbitalBodies { get { return orbitalBodies; } }
        //public List<OrbitalBodyDrawData> OrbitalDrawData { get { return orbitalDrawData; } }
        public Vector2 Position { get { return sprite.Position; } set { sprite.Position = value; } }
        public Color Color { get { return sprite.Color; } set { sprite.Color = value; } }
        public string Name { get { return name; } }

        /// <summary>
        /// When a star is created, it uses GetRandomNumber() to generate data about size,
        /// rotation and orbital bodies.
        /// </summary>
        public Star()
        {
            sprite = new Sprite(ContentStorageManager.Get<Texture2D>("Star"));

            sprite.Origin = (sprite.GetTextureSize() / 2);
            sprite.Rotation = GameControl.GetRandomNumber(8);
            sprite.Scale = (4 + GameControl.GetRandomNumber(6)) * .015f;
            totalOrbitalBodies = GameControl.GetRandomNumber(6);
            name = StarNames.GetRandomUnusedName();
            orbitalBodies = GalaxyGenerator.GenerateSolarSystem(totalOrbitalBodies, Color);
        }
        
        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb);
        }
    }

    /// <summary>
    /// StarNames holds a list of all possible star names and 
    ///contains several useful methods for extracting random unused names from the list.
    /// </summary>
    public static class StarNames
    {
        //Total number of names
        public const ushort TOTAL_NAMES = 415;

        /// <summary>
        /// Names taken from http://www.astro.wisc.edu/~dolan/constellations/starname_list.html
        /// </summary>
        public static readonly string[] names = { "ACHERNAR","Achird","ACRUX",
        "Acubens","ADARA","Adhafera","Adhil","AGENA",
        "Ain al Rami","Ain","Al Anz","Al Kalb al Rai",
        "Al Minliar al Asad","Al Minliar al Shuja",
        "Aladfar","Alathfar","Albaldah","Albali","ALBIREO",
        "Alchiba","ALCOR","ALCYONE","ALDEBARAN","ALDERAMIN",
        "Alkalurops","Alkes","Alkurhah","ALMAAK","ALNAIR","ALNATH",
        "ALNILAM","ALNITAK","Alniyat","ALPHARD","ALPHEKKA","ALPHERATZ",
        "Alrai","Alrisha","Alsafi","Alsciaukat","ALSHAIN","Alshat",
        "Alsuhail","ALTAIR","Altarf","Alterf","Aludra","Alula Australis",
        "Alula Borealis","Alya","Alzirr","Ancha","Angetenar","ANKAA",
        "Anser","ANTARES","ARCTURUS","Arkab Posterior","Arkab Prior",
        "ARNEB","Arrakis","Ascella","Asellus Australis","Asellus Borealis",
        "Asellus Primus","Asellus Secondus","Asellus Tertius","Asterope",
        "Atik","Atlas","Auva","Avior","Azelfafage","Azha","Azmidiske","Baham",
        "Baten Kaitos","Becrux","Beid","BELLATRIX","BETELGEUSE","Botein",
        "Brachium","CANOPUS","CAPELLA","Caph","CASTOR","Cebalrai","Celaeno",
        "Chara","Chort","COR CAROLI","Cursa","Dabih","Deneb Algedi","Deneb Dulfim",
        "Deneb el Okab","Deneb el Okab","Deneb Kaitos Shemali","DENEB","DENEBOLA",
        "Dheneb","Diadem","DIPHDA","Double Double","Dschubba","Dsiban","DUBHE","Ed Asich",
        "Electra","ELNATH","ENIF","ETAMIN","FOMALHAUT","Fornacis","Fum al Samakah","Furud",
        "Gacrux","Gianfar","Gienah Cygni","Gienah Ghurab","Gomeisa","Gorgonea Quarta",
        "Gorgonea Secunda","Gorgonea Tertia","Graffias","Grafias","Grumium","HADAR",
        "Haedi","HAMAL","Hassaleh","Head of Hydrus","Herschel's Garnet Star","Heze",
        "Hoedus II","Homam","Hyadum I","Hyadum II","IZAR","Jabbah","Kaffaljidhma","Kajam",
        "KAUS AUSTRALIS","Kaus Borealis","Kaus Meridionalis","Keid","Kitalpha","KOCAB",
        "Kornephoros","Kraz","Kuma","Lesath","Maasym","Maia","Marfak","Marfak","Marfic","Marfik",
        "MARKAB","Matar","Mebsuta","MEGREZ","Meissa","Mekbuda","Menkalinan","MENKAR","Menkar",
        "Menkent","Menkib","MERAK","Merga","Merope","Mesarthim","Metallah","Miaplacidus",
        "Minkar","MINTAKA","MIRA","MIRACH","Miram","MIRPHAK","MIZAR","Mufrid","Muliphen","Murzim",
        "Muscida","Muscida","Muscida","Nair al Saif","Naos","Nash","Nashira","Nekkar","NIHAL",
        "Nodus Secundus","NUNKI","Nusakan","Peacock","PHAD","Phaet","Pherkad Minor","Pherkad",
        "Pleione","Polaris Australis","POLARIS","POLLUX","Porrima","Praecipua","Prima Giedi",
        "PROCYON","Propus","Propus","Propus","Rana","Ras Elased Australis","Ras Elased Borealis",
        "RASALGETHI","RASALHAGUE","Rastaban","REGULUS","Rigel Kentaurus","RIGEL","Rijl al Awwa",
        "Rotanev","Ruchba","Ruchbah","Rukbat","Sabik","Sadalachbia","SADALMELIK","Sadalsuud","Sadr",
        "SAIPH","Salm","Sargas","Sarin","Sceptrum","SCHEAT","Secunda Giedi","Segin","Seginus","Sham",
        "Sharatan","SHAULA","SHEDIR","Sheliak","SIRIUS","Situla","Skat","SPICA","Sterope II","Sualocin",
        "Subra","Suhail al Muhlif","Sulafat","Syrma","Tabit","Talitha","Tania Australis","Tania Borealis",
        "TARAZED","Taygeta","Tegmen","Tejat Posterior","Terebellum","Thabit","Theemim","THUBAN",
        "Torcularis Septentrionalis","Turais","Tyl","UNUKALHAI","VEGA","VINDEMIATRIX","Wasat",
        "Wezen","Wezn","Yed Posterior","Yed Prior","Yildun","Zaniah","Zaurak","Zavijah","Zibal",
        "Zosma","Zuben Elakrab","Zuben Elakribi","Zuben Elgenubi","Zuben Elschemali" };

        //A list of names yet unused for generating stars.
        private static List<string> unusedNames = new List<string>(names);

        /// <summary>
        /// Gets a random name from the list of names. 
        /// This method can return duplicate names.
        /// </summary>
        public static string GetRandomName()
        {
            return names[GameControl.GetRandomNumber(TOTAL_NAMES)];
        }

        /// <summary>
        /// Gets a random name from the list of names. 
        /// This method does not return duplicate names.
        /// </summary>
        public static string GetRandomUnusedName()
        {
            ushort index = (ushort)(GameControl.GetRandomNumber(unusedNames.Count) - 1);
            string retStr = unusedNames[index];
            unusedNames.RemoveAt(index);

            return retStr;
        }

        /// <summary>
        /// This method resets the used name list.
        /// </summary>
        public static void ResetUsedNames()
        {
            //Actually an 'unused' name list implementation rather than a 'used' name list.
            unusedNames = new List<string>(names);
        }
    }
}
