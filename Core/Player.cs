using Rftg.Dice;
using Rftg.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    public class Player
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
            ConstructionQueue = new ConstructionQueue();
        }

        public Game Game { get; protected set; }
        public int Credits { get; internal set; }
        public DieCollection Citizenry { get; protected set; }
        public DieCollection Cup { get; protected set; }
        public TileCollection Tableau { get; protected set; }
        public ConstructionQueue ConstructionQueue { get; internal set; }

        public void Gain(Ownable tile)
        {
            Tableau.Add(tile);

            if (tile is GainPower)
            {
                ((GainPower)tile).GainFor(this);
            }
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

        internal IEnumerable<Ownable> Scout(object die, params Ownable[] discards)
        {
            Game.AbandonedTiles.AddRange(discards);
            return Game.Bag.DrawRandom(discards.Length + 1).ToArray();
        }

        internal void Develop(params object[] dice)
        {
            foreach (var die in dice)
            {
                ConstructionQueue.Developers.Add(die);

                if (ConstructionQueue.Developers.Count() >= ConstructionQueue.Developments.Peek().Cost)
                {
                    Tableau.Add(ConstructionQueue.Developments.Pop());
                    Cup.AddRange(ConstructionQueue.Developers);
                    ConstructionQueue.Developers.Clear();
                }
            }
        }
    }
}