using Rftg.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class Player
    {
        internal Player(Ownable startTile)
        {
            Citizenry = new DieCollection();
            startTile.AddTo(this);
        }

        public DieCollection Citizenry { get; private set; }
    }
}
