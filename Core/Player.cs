using Rftg.Dice;
using Rftg.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class Player
    {
        internal Player(Game game)
        {
            Game = game;
            Credits = 1;
            Citizenry = new DieCollection();
            Citizenry.Add(new Dice.Home());
            Citizenry.Add(new Dice.Home());
            Cup = new DieCollection();
            Cup.Add(new Dice.Home());
            Cup.Add(new Dice.Home());
            Cup.Add(new Dice.Home());
        }

        public Game Game { get; protected set; }
        public int Credits { get; internal set; }
        public DieCollection Citizenry { get; protected set; }
        public DieCollection Cup { get; protected set; }

        internal void MoveToCup(object die)
        {
            Citizenry.Remove(die);
            Cup.Add(die);
        }

        internal void Stock()
        {
            Credits += 2;
        }
    }
}
