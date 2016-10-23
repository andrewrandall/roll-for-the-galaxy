using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rftg.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg.Tiles
{
    [TestClass]
    public class AlienArchaeologyTests
    {
        Player player;
        AlienArchaeology tile;

        [TestInitialize]
        public void BeforeEach()
        {
            player = new Player(new Game());
            tile = new AlienArchaeology();
            player.Gain(tile);
        }

        [TestMethod]
        public void Adds_Two_Credits_When_AlienTech_Explorer()
        {
            var startingCredits = player.Credits;

            player.Stock(new AlienTechnology());

            Assert.AreEqual(4, player.Credits - startingCredits);
        }
    }
}
