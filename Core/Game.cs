using Rftg.Phases;
using Rftg.Tiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    public class Game
    {
        public Game()
        {
            Phases = new []
            {
                new Ship()
            };
            AbandonedTiles = new List<Ownable>();
        }

        public IEnumerable<Phase> Phases { get; protected set; }

        public Bag Bag { get; internal set; }

        public List<Ownable> AbandonedTiles { get; internal set; }
    }
}
