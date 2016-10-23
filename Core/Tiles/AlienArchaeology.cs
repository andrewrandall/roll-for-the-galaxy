using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class AlienArchaeology : Ownable, Phases.StockPower
    {
        public int Cost => 1;

        public void GainFor(Player newOwner)
        {
            
        }

        public void Execute(object die, Player player)
        {
            player.Credits += 2;
        }
    }
}
