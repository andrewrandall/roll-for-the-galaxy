using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    class DoNothingOwnable : Ownable
    {
        public int Cost => 0;

        public void GainFor(Player newOwner) { }
    }
}
