using NUnit.Framework;
using desktopidlegamesoftwareengineering.scripts.managers;
using Godot;

namespace UnitTests
{
    [TestFixture] //marks this class as a test class
    public class GameManagerTests
    {
        private GameManager _gameManager;

        [SetUp] //runs before each test to create a fresh GameManager instance
        public void Setup()
        {
            _gameManager = GameManager.Instance;
            if (_gameManager == null)
            {
                _gameManager = new GameManager(true);
            }
        }


        [Test] //test 1: adding currency should increase currency count
        public void AddCurrency_ShouldIncreaseCurrency()
        {
            _gameManager.AddCurrency(100);
            Assert.AreEqual(100, _gameManager.Currency);
        }

        [Test] //test 2: buying a castle should work
        public void PurchaseCastle_ShouldSucceed_WhenEnoughCurrency()
        {
            _gameManager.AddCurrency(100);
            bool success = _gameManager.PurchaseCastle();
            Assert.IsTrue(success); //purchase should succeed
            Assert.IsTrue(_gameManager.CastlePurchased); //CastlePurchased should be true
            Assert.AreEqual(0, _gameManager.Currency); //currency should be deducted
        }

        [Test] //test 3: buying a ship should fail if castle isn't bought first
        public void PurchaseShip_ShouldFail_WhenCastleNotPurchased()
        {
            _gameManager.AddCurrency(200);
            bool success = _gameManager.PurchaseShip();
            Assert.IsFalse(success); //purchase should fail because castle isn’t bought
        }
    }
}
