using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Powerups;
using GalaxyShooterInternals.Utility;
using NUnit.Framework;
using NSubstitute;


namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class SpeedBoostTest
    {
        [Test]
        public void SpeedBoostCanBeInstantiated()
        {
            SpeedBoost powerup = new SpeedBoost();

            Assert.AreEqual(10f, powerup.Duration());
        }

        [Test]
        public void SpeedBoostCanBeInstantiatedWithCustomDuration()
        {
            SpeedBoost powerup = new SpeedBoost(20f);

            Assert.AreEqual(20f, powerup.Duration());
        }

        [Test]
        public void SpeedBoostCanBeInstantiatedWithNullDuration()
        {
            SpeedBoost powerup = new SpeedBoost(null);

            Assert.AreEqual(null, powerup.Duration());
        }

        [Test]
        public void SpeedBoostIdentifier()
        {
            SpeedBoost powerup = new SpeedBoost(null);

            Assert.AreEqual(Powerups.SPEED, powerup.Identifier());
        }

        [Test]
        public void AppliesBoostToPlayer()
        {
            var player = Substitute.For<IPlayer>();

            SpeedBoost powerup = new SpeedBoost();

            powerup.Apply(player);

            player.Received().MultiplySpeed(1.5f);
        }

        [Test]
        public void AppliesCustomBoostToPlayer()
        {
            var player = Substitute.For<IPlayer>();

            SpeedBoost powerup = new SpeedBoost(10f, 3f);

            powerup.Apply(player);

            player.Received().MultiplySpeed(3f);
        }

        [Test]
        public void RemovesBoostFromPlayer()
        {
            var player = Substitute.For<IPlayer>();

            SpeedBoost powerup = new SpeedBoost();

            powerup.Remove(player);

            player.Received().DefaultSpeed();
        }
    }
}
