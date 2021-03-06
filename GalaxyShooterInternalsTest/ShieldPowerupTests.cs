﻿using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Powerups;
using GalaxyShooterInternals.Utility;
using NUnit.Framework;
using NSubstitute;


namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class ShieldPowerupTests
    {
        [Test]
        public void ShieldPowerupCanBeInstantiated()
        {
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield);

            Assert.AreEqual(10f, powerup.Duration());
        }

        [Test]
        public void ShieldPowerupCanBeInstnatiatedWithDuration()
        {
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield, 20f);

            Assert.AreEqual(20f, powerup.Duration());
        }

        [Test]
        public void ShieldPowerupCanBeInstnatiatedWithoutDuration()
        {
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield, null);

            Assert.AreEqual(null, powerup.Duration());
        }

        [Test]
        public void ShieldPowerupIdentifier()
        {
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield, null);

            Assert.AreEqual(Powerups.Shield, powerup.Identifier());
        }

        [Test]
        public void ShieldPowerupAppliesShield()
        {
            var player = Substitute.For<IShieldable>();
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield);

            powerup.Apply(player);

            player.Received().ApplyShield(shield);
        }

        [Test]
        public void ShieldPowerupRemovesShield()
        {
            var player = Substitute.For<IShieldable>();
            var shield = Substitute.For<IShield>();

            ShieldPowerup powerup = new ShieldPowerup(shield);

            powerup.Remove(player);

            player.Received().RemoveShield();
        }
    }
}
