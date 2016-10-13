using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rftg
{
    [TestClass]
    public class Space_Piracy_Tests
    {
        [TestMethod]
        public void Adds_Red_Die_To_Citizenry_When_Taken()
        {
            var player = new Player(new SpacePiracy());

            Assert.AreEqual(1, player.Citizenry.Count(d => d is Dice.Military));
        }
    }
}