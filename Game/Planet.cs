using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceExplorerXNAWF
{
    public class Planet : OrbitalBody
    {
        public Planet(Color starColor, OrbitalBodyDrawData drawBody)
            : base()
        {
            pType = OrbitalCharacteristics.PlanetTypes[((-2) + (GameControl.GetRandomNumber(6) + GameControl.GetRandomNumber(6)))];
            mineralTrait = OrbitalCharacteristics.MineralTraits[((-2) + (GameControl.GetRandomNumber(4) + GameControl.GetRandomNumber(4)))];
            gravityTrait = OrbitalCharacteristics.GravityTraits[GameControl.GetRandomNumber(3)];
            scaleTrait = OrbitalCharacteristics.ScaleTraits[((-2) + (GameControl.GetRandomNumber(4) + GameControl.GetRandomNumber(4)))];
            miscTrait = OrbitalCharacteristics.MiscTraits[GameControl.GetRandomNumber(6)];
            if (GameControl.GetRandomNumber(101) < 16)
            {
                rareTrait = OrbitalCharacteristics.RareTraits[GameControl.GetRandomNumber(6)];
            }
            this.drawBody = drawBody;
        }
    }
}
