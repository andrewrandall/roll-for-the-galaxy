using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class HiddenFortress : Ownable
    {
        public int Cost => 2;

        public void GainFor(Player newOwner)
        {
            newOwner.Citizenry.Add(new Dice.Military());
        }
    }
}
