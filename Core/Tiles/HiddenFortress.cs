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
        public void AddTo(Player newOwner)
        {
            newOwner.Citizenry.Add(new Dice.Military());
        }
    }
}
