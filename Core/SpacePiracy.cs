using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class SpacePiracy : Ownable
    {
        public void AddTo(Player newOwner)
        {
            newOwner.Citizenry.Add(new Dice.Military());
        }
    }
}
