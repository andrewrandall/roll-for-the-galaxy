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
            Tableau = new TileCollection();
        }

        public Game Game { get; protected set; }
        public int Credits { get; internal set; }
        public DieCollection Citizenry { get; protected set; }
        public DieCollection Cup { get; protected set; }
        public TileCollection Tableau { get; protected set; }

        public void Gain(Ownable tile)
        {
            Tableau.Add(tile);
            tile.GainFor(this);
        }

        public void MoveToCup(object die)
        {
            Citizenry.Remove(die);
            Cup.Add(die);
        }

        public void Stock(object die)
        {
            Credits += 2;

            foreach (var power in Tableau.GetPowers<Phases.StockPower>())
            {
                power.Execute(die, this);
            }
        }
    }
}
