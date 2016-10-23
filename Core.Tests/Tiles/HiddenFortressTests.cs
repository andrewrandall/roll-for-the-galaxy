using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rftg.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    [TestClass]
    public class Hidden_Fortress_Tests
    {
        MockPlayer player;
        MockGame game;
        HiddenFortress tile;

        [TestInitialize]
        public void BeforeEach()
        {
            tile = new HiddenFortress();
            game = new MockGame();
            player = new MockPlayer(game);
        }

        [TestMethod]
        public void Adds_Military_Die_To_Citizenry_When_Taken()
        {
            player.SetCitizenry();
            var startCount = CountMilitary();

            tile.GainFor(player);

            Assert.AreEqual(1, CountMilitary() - startCount);
        }

        private int CountMilitary() => player.Citizenry.Count(d => d is Dice.Military);
    }
}