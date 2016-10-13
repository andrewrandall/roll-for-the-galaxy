using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class SpacePiracy : Ownable
    {
        private Player owner;

        public void AddTo(Player newOwner)
        {
            owner = newOwner;
            newOwner.Citizenry.Add(new Dice.Military());
        }

        internal void EndShipPhase()
        {
            double x = owner.Citizenry.Count(d => d is Dice.Military) / 2d;
            int x2 = (int)Math.Ceiling(x);
            owner.Credits += x2;
        }
    }
}
