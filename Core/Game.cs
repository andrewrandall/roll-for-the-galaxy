using Rftg.Phases;
using System;
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
        }

        public IEnumerable<Phase> Phases { get; protected set; }
    }
}
