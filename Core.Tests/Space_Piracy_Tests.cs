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

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_One_Red()
        {
            var tile = new SpacePiracy();
            var player = new Player(tile);

            tile.EndShipPhase();

            Assert.AreEqual(2, player.Credits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Zero_Red()
        {
            var tile = new SpacePiracy();
            var player = new Player(tile);
            player.MoveToCup(player.Citizenry.First(d => d is Dice.Military));

            tile.EndShipPhase();

            Assert.AreEqual(1, player.Credits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Two_Red()
        {
            var tile = new SpacePiracy();
            var player = new Player(tile);
            player.Citizenry.Add(new Dice.Military());

            tile.EndShipPhase();

            Assert.AreEqual(2, player.Credits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Three_Red()
        {
            var tile = new SpacePiracy();
            var player = new Player(tile);
            player.Citizenry.Add(new Dice.Military());
            player.Citizenry.Add(new Dice.Military());

            tile.EndShipPhase();

            Assert.AreEqual(3, player.Credits);
        }

        [TestMethod]
        public void Gains_Money_On_Ship_Phase_End_Four_Red()
        {
            var tile = new SpacePiracy();
            var player = new Player(tile);
            player.Citizenry.Add(new Dice.Military());
            player.Citizenry.Add(new Dice.Military());
            player.Citizenry.Add(new Dice.Military());

            tile.EndShipPhase();

            Assert.AreEqual(3, player.Credits);
        }
    }
}