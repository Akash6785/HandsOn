using Moq;
using NUnit.Framework;
using System;

namespace PlayersManagerLib.UnitTest
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> playerMapper;

        [OneTimeSetUp]
        public void Inint()
        {
            playerMapper = new Mock<IPlayerMapper>();          
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void RegisterNewPlayerNameTest(string name)
        {
            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(name, playerMapper.Object));
        }

        [Test]
        [TestCase("Ashwin")]
        public void RegisterNewPlayer_DbTest(string name)
        {
            playerMapper.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);

            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(name, playerMapper.Object));
        }
        
        [Test]
        [TestCase("Ashwin")]
        public void RegisterNewPlayer_AddTest(string name)
        {
            playerMapper.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
            playerMapper.Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));

            var result = Player.RegisterNewPlayer(name, playerMapper.Object);

            Assert.That(result, Is.TypeOf<Player>());
            Assert.That(result.Country, Is.EqualTo("India").IgnoreCase);
        }
    }
}
