using GalaxyShooterInternals.Entities;
using GalaxyShooterInternals.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class EnemyTests
    {
        [Test]
        public void CanInstantiateEnemy()
        {
            Enemy enemy = new Enemy(10f,
                                    Substitute.For<IHealth>());

            Assert.AreEqual(10f, enemy.CurrentSpeed());
        }

        [Test]
        public void HealthInitializedCorrectly()
        {
            var health = Substitute.For<IHealth>();
            Enemy enemy = new Enemy(10f, health);

            enemy.SufferDamage(1);

            health.ReceivedWithAnyArgs().Damage(1);
        }

        [Test]
        public void HealthMethodsCalledCorrectly()
        {
            var health = Substitute.For<IHealth>();
            Enemy enemy = new Enemy(10f, health);

            enemy.SufferDamage(1);

            health.Received(1).Damage(1);
            health.Received(2).Total();
        }
    }
}
