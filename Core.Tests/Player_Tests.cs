using Rftg.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    [TestClass]
    public class Player_Tests
    {
        Game game;
        Player player;

        [TestInitialize]
        public void BeforeEach()
        {
            game = new Game();
            player = new Player(game, new DoNothingOwnable());
        }

        [TestMethod]
        public void Starts_With_Two_Home_Dice_In_Citizenry()
        {
            Assert.AreEqual(2, player.Citizenry.Count());
            Assert.IsTrue(player.Citizenry.All(d => d is Dice.Home));
        }

        [TestMethod]
        public void Starts_With_Three_Home_Dice_In_Cup()
        {
            Assert.AreEqual(3, player.Cup.Count());
            Assert.IsTrue(player.Cup.All(d => d is Dice.Home));
        }

        [TestMethod]
        public void Starts_With_1_Credit()
        {
            Assert.AreEqual(1, player.Credits);
        }
    }
}