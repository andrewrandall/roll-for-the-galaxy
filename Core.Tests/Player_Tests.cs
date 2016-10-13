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
        [TestMethod]
        public void Starts_With_Two_White_Dice()
        {
            var player = new Player(new DoNothingOwnable());

            Assert.AreEqual(2, player.Citizenry.Count());
            Assert.IsTrue(player.Citizenry.All(d => d is Dice.Home));
        }
    }
}
