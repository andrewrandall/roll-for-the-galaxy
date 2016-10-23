using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Rftg.Tiles;
using System.Collections;

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

        internal void GenerateRandomBag(int v)
        {
            SetBag(Enumerable.Range(0, v).Select(x => new Mock<Ownable>().Object).ToArray());
        }
    }
}
