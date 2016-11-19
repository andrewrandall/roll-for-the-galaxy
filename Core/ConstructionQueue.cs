using Rftg.Dice;
using Rftg.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    public class ConstructionQueue
    {
        public ConstructionQueue()
        {
            Developers = new DieCollection();
            Developments = new TileCollection();
            Worlds = new TileCollection();
        }

        public DieCollection Developers { get; protected set; }
        public TileCollection Developments { get; private set; }
        public TileCollection Worlds { get; private set; }
    }
}
