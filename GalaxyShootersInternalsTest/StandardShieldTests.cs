using GalaxyShooterInternals;
using NUnit.Framework;

namespace GalaxyShootersInternalsTest
{
    [TestFixture]
    public class StandardShieldTests
    {
        [Test]
        public void StandardShieldCanBeInstantiated()
        {
            StandardShield shield = new StandardShield();

            Assert.IsTrue(shield.StillAvailable());
        }

        [Test]
        public void CanBeDamaged()
        {
            StandardShield shield = new StandardShield();

            var depleted = shield.DamageShield();

            Assert.IsTrue(depleted);
            Assert.IsFalse(shield.StillAvailable());
        }

        [Test]
        public void CanBeDamagedWithCustomAmount()
        {
            StandardShield shield = new StandardShield();

            var depleted = shield.DamageShield(10);

            Assert.IsTrue(depleted);
            Assert.IsFalse(shield.StillAvailable());
        }

        [Test]
        public void CannotBeDamagedWithZeroDamage()
        {
            StandardShield shield = new StandardShield();

            var depleted = shield.DamageShield(0);

            Assert.IsFalse(depleted);
            Assert.IsTrue(shield.StillAvailable());
        }

        [Test]
        public void CannotBeDamagedWithNegativeDamage()
        {
            StandardShield shield = new StandardShield();

            var depleted = shield.DamageShield(-1);

            Assert.IsFalse(depleted);
            Assert.IsTrue(shield.StillAvailable());
        }
    }
}
