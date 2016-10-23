using Rftg.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class AlienRosettaStoneWorld : Ownable, GainPower
    {
        public int Cost => 1;

        public void GainFor(Player player)
        {
            player.Citizenry.Add(new AlienTechnology());
        }
    }
}
