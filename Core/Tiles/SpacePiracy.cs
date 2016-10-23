using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class SpacePiracy : Ownable, GainPower
    {
        private Player owner;

        public int Cost => 0;

        public void GainFor(Player newOwner)
        {
            owner = newOwner;
            newOwner.Game.Phases.Where(p => p is Ship).Single().Ending += ShipPhaseEnding;
        }

        private void ShipPhaseEnding(object sender, EventArgs e)
        {
            double x = owner.Citizenry.Count(d => d is Dice.Military) / 2d;
            int x2 = (int)Math.Ceiling(x);
            owner.Credits += x2;
        }
    }
}
