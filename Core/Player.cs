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
            Credits = 1;
            Citizenry = new DieCollection();
            Citizenry.Add(new Dice.Home());
            Citizenry.Add(new Dice.Home());
            Cup = new DieCollection();
            Cup.Add(new Dice.Home());
            Cup.Add(new Dice.Home());
            Cup.Add(new Dice.Home());
            startTile.AddTo(this);
        }

        public int Credits { get; internal set; }
        public DieCollection Citizenry { get; private set; }
        public DieCollection Cup { get; private set; }

        internal void MoveToCup(object die)
        {
            Citizenry.Remove(die);
            Cup.Add(die);
        }
    }
}
