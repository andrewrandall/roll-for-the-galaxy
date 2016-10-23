using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Rftg.Tiles;

namespace Rftg
{
    class MockGame : Game
    {
        public MockGame()
        {
            Phases = new List<Phase>()
            {
                new MockShip()
            };
        }

        internal void SetBag(params Ownable[] tiles)
        {
            Bag = new Bag(tiles);
        }
    }
}
