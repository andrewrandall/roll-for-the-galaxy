using Rftg.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Rftg.Phases;

namespace Rftg
{
    [TestClass]
    public class PlayerTests
    {
        MockGame game;
        Player player;

        [TestInitialize]
        public void BeforeEach()
        {
            game = new MockGame();
            player = new Player(game);
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

        [TestMethod]
        public void Stock_Takes_Two_Credits()
        {
            var startingCredits = player.Credits;

            player.Stock(new object());

            Assert.AreEqual(2, player.Credits - startingCredits);
        }

        [TestMethod]
        public void Gain_Executes_GainPower()
        {
            var mockTile = new Mock<Ownable>();
            var mockGainPower = mockTile.As<GainPower>();

            player.Gain(mockTile.Object);

            mockGainPower.Verify(x => x.GainFor(player));
        }

        [TestMethod]
        public void Stock_Executes_StockPowers()
        {
            var mockTile = new Mock<Ownable>();
            var mockStockPower = mockTile.As<StockPower>();
            player.Tableau.Add(mockTile.Object);
            var die = new AlienArchaeology();

            player.Stock(die);

            mockStockPower.Verify(x => x.Execute(die, player));
        }

        [TestMethod]
        public void Scout_Gains_Tile_From_Bag()
        {
            var tile = new Mock<Ownable>();
            game.SetBag(tile.Object);

            var tiles = player.Scout(new object());

            Assert.AreEqual(1, tiles.Count());
            Assert.AreEqual(0, game.Bag.Count());
            Assert.AreSame(tile.Object, tiles.Single());
        }

        [TestMethod]
        public void Scout_Gains_Tiles_From_Bag_When_Discards()
        {
            game.GenerateRandomBag(10);
            var discards = Enumerable.Range(0, 3).Select(x => new Mock<Ownable>().Object).ToArray();

            var tiles = player.Scout(new object(), discards);

            Assert.AreEqual(4, tiles.Count());
            Assert.AreEqual(6, game.Bag.Count());
            CollectionAssert.AreEquivalent(discards, game.AbandonedTiles);
        }

        [TestMethod]
        public void Develop_Stores_Developer()
        {
            var development = new Mock<Development>();
            development.Setup(d => d.Cost).Returns(10);
            player.ConstructionQueue.Developments.Add(development.Object);
            var die = new object();

            player.Develop(die);

            Assert.IsTrue(player.ConstructionQueue.Developers.Contains(die));
        }

        [TestMethod]
        public void Develop_Starts_Empty()
        {
            Assert.AreEqual(0, player.ConstructionQueue.Developers.Count());
        }

        // todo: split up assertions below

        [TestMethod]
        public void Develop_Finishes_Building_1()
        {
            var development = new Mock<Development>();
            development.Setup(d => d.Cost).Returns(1);
            player.ConstructionQueue.Developments.Add(development.Object);
            var die = new object();

            player.Develop(die);

            Assert.IsTrue(player.Tableau.Contains(development.Object), "Built Tile");
            Assert.IsFalse(player.ConstructionQueue.Developments.Contains(development.Object), "Moves Tile from Queue");
            Assert.IsTrue(player.Cup.Contains(die), "Moved die to cup");
            Assert.IsFalse(player.ConstructionQueue.Developers.Contains(die), "Doesn't store developer");
        }

        [TestMethod]
        public void Develop_Finishes_Building_2()
        {
            var development = new Mock<Development>();
            development.Setup(d => d.Cost).Returns(2);
            player.ConstructionQueue.Developments.Add(development.Object);
            var dice = Enumerable.Range(0, 2).Select(x => new object()).ToArray();

            player.Develop(dice);

            Assert.IsTrue(player.Tableau.Contains(development.Object), "Built Tile");
            Assert.IsFalse(player.ConstructionQueue.Developments.Contains(development.Object), "Moves Tile from Queue");
            Assert.IsTrue(dice.All(d => player.Cup.Contains(d)), "Moved die to cup");
            Assert.IsFalse(dice.Any(d => player.ConstructionQueue.Developers.Contains(d)), "Doesn't store developer");
        }

        [TestMethod]
        public void Develop_DoesNotFinish_Building_2()
        {
            var development = new Mock<Development>();
            development.Setup(d => d.Cost).Returns(2);
            player.ConstructionQueue.Developments.Add(development.Object);
            var die = new object();

            player.Develop(die);

            Assert.IsTrue(player.ConstructionQueue.Developments.Contains(development.Object), "Leaves tile in Queue");
            Assert.IsFalse(player.Tableau.Contains(development.Object), "Does not build tile");
            Assert.IsTrue(player.ConstructionQueue.Developers.Contains(die), "Stores developer");
            Assert.IsFalse(player.Cup.Contains(die), "Does not move developer to cup");
        }

        [TestMethod]
        public void Develop_Finishes_Two_Buildings()
        {
            var developments = Enumerable.Range(0, 2).Select(i => new MockDevelopment() { Cost = 1 }).ToArray();
            foreach (var development in developments)
            {
                player.ConstructionQueue.Developments.Add(development);
            }
            var dice = Enumerable.Range(0, 2).Select(i => new object()).ToArray();

            player.Develop(dice);

            Assert.IsTrue(developments.All(d => player.Tableau.Contains(d)), "Built tiles");
            Assert.IsFalse(developments.Any(d => player.ConstructionQueue.Developments.Contains(d)), "Dequeued tiles");
            Assert.IsTrue(dice.All(d => player.Cup.Contains(d)), "Dice moved to cup");
            Assert.IsFalse(dice.Any(d => player.ConstructionQueue.Developers.Contains(d)), "Dice moved to cup");
        }
    }
}