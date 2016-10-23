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
    public class SpacePiracyTests
    {
        MockPlayer player;
        MockGame game;
        MockShip shipPhase;
        SpacePiracy tile;
        int startingCredits;

        [TestInitialize]
        public void BeforeEach()
        {
            tile = new SpacePiracy();
            game = new MockGame();
            shipPhase = (MockShip)game.Phases.Single(p => p is MockShip);
            player = new MockPlayer(game);
            tile.AddTo(player);
            startingCredits = player.Credits;
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Zero_Military()
        {
            player.SetCitizenry();

            shipPhase.End();

            Assert.AreEqual(0, player.Credits - startingCredits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Two_Military()
        {
            player.SetCitizenry(new Dice.Military(), new Dice.Military());

            shipPhase.End();

            Assert.AreEqual(1, player.Credits - startingCredits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Three_Military()
        {
            player.SetCitizenry(new Dice.Military(), new Dice.Military(), new Dice.Military());

            shipPhase.End();

            Assert.AreEqual(2, player.Credits - startingCredits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Four_Military()
        {
            player.SetCitizenry(new Dice.Military(), new Dice.Military(), new Dice.Military(), new Dice.Military());

            shipPhase.End();

            Assert.AreEqual(2, player.Credits - startingCredits);
        }
    }
}