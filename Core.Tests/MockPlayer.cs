using Rftg.Dice;
using Rftg.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    class MockPlayer : Player
    {
        public MockPlayer(MockGame game)
            : base(game, new DoNothingOwnable())
        {
            Game = game;
            Credits = 0;
            Citizenry = new DieCollection();
            Cup = new DieCollection();
        }

        public void SetCitizenry(params object[] dice)
        {
            Citizenry = new DieCollection();

            foreach (var die in dice)
                Citizenry.Add(die);
        }
    }
}
