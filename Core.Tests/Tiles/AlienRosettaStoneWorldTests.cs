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
    public class AlienRosettaStoneWorldTests
    {
        Player player;
        AlienRosettaStoneWorld tile;

        [TestInitialize]
        public void BeforeEach()
        {
            player = new Player(new Game());
            tile = new AlienRosettaStoneWorld();
        }

        [TestMethod]
        public void Adds_Alien_Tech_To_Citizenry()
        {
            var techsBefore = CountTechs();

            player.Gain(tile);

            Assert.AreEqual(1, CountTechs() - techsBefore);
        }

        private int CountTechs() => player.Citizenry.Count(c => c is AlienTechnology);
    }
}
