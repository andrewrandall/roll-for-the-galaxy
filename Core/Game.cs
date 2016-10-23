using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class Game
    {
        public Game()
        {
            Phases = new List<Phase>()
            {
                new Ship()
            };
        }

        public List<Phase> Phases { get; protected set; }
    }
}
