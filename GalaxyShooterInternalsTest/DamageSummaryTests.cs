using GalaxyShooterInternals.Entities;
using GalaxyShooterInternals.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class DamageSummaryTests
    {
        [Test]
        public void PlayerTakesDamageStillAlive()
        {
            var player = new Player(10f,
                                    Substitute.For<IWeapon>(),
                                    Health());

            var summary = player.SufferDamage(1);

            Assert.IsTrue(summary.Damaged);
            Assert.IsFalse(summary.Defeated);
            Assert.AreEqual(summary.InitialHealth, 5);
            Assert.AreEqual(summary.RemainingHealth, 4);
        }

        [Test]
        public void PlayerWithShieldTakesNoDamage()
        {
            var player = new Player(10f,
                                    Substitute.For<IWeapon>(),
                                    Health(),
                                    Shield());

            var summary = player.SufferDamage(1);

            Assert.IsFalse(summary.Damaged);
            Assert.IsFalse(summary.Defeated);
            Assert.Null(summary.InitialHealth);
            Assert.Null(summary.RemainingHealth);
        }

        [Test]
        public void PlayerTakesLeathalDamage()
        {
            var player = new Player(10f,
                                    Substitute.For<IWeapon>(),
                                    Health());

            // First one's not lethal
            player.SufferDamage(1);

            // That's the good stuff
            var summary = player.SufferDamage(4);

            Assert.IsTrue(summary.Damaged);
            Assert.IsTrue(summary.Defeated);
            Assert.AreEqual(summary.InitialHealth, 4);
            Assert.AreEqual(summary.RemainingHealth, 0);

        }

        [Test]
        public void EnemyTakesDamageStillAlive()
        {
            var player = new Enemy(10f,
                                   Health());

            var summary = player.SufferDamage(1);

            Assert.IsTrue(summary.Damaged);
            Assert.IsFalse(summary.Defeated);
            Assert.AreEqual(summary.InitialHealth, 5);
            Assert.AreEqual(summary.RemainingHealth, 4);
        }

        [Test]
        public void EnemyTakesLethalDamage()
        {
            var player = new Enemy(10f,
                                   Health());

            // First one's not lethal
            player.SufferDamage(1);

            // That's the good stuff
            var summary = player.SufferDamage(4);

            Assert.IsTrue(summary.Damaged);
            Assert.IsTrue(summary.Defeated);
            Assert.AreEqual(summary.InitialHealth, 4);
            Assert.AreEqual(summary.RemainingHealth, 0);

        }

        private IHealth Health()
        {
            var health = Substitute.For<IHealth>();

            health.Total().Returns(5, 4, 4, 0);
            health.Damage(1).ReturnsForAnyArgs(false, true);

            return health;
        }

        private IShield Shield()
        {
            var shield = Substitute.For<IShield>();

            shield.StillAvailable().Returns(true, false);
            shield.DamageShield(1).ReturnsForAnyArgs(true);

            return shield;
        }
    }
}
