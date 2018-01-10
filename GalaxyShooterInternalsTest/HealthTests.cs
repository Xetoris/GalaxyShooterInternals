using GalaxyShooterInternals.Entities;
using NUnit.Framework;

namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class HealthTests
    {
        [Test]
        public void HealthCanBeInitialized()
        {
            Health health = new Health();

            Assert.AreEqual(3, health.Total());
        }

        [Test]
        public void HealthCanBeInitializedWithValue()
        {
            Health health = new Health(5);

            Assert.AreEqual(5, health.Total());
        }

        [Test]
        public void CanSufferDamage()
        {
            Health health = new Health(3);

            health.Damage(2);

            Assert.AreEqual(1, health.Total());
        }

        [Test]
        public void CannotSufferZeroDamage()
        {
            Health health = new Health(3);

            health.Damage(0);

            Assert.AreEqual(3, health.Total());
        }

        [Test]
        public void CannotSufferNegativeDamage()
        {
            Health health = new Health(3);

            health.Damage(-1);

            Assert.AreEqual(3, health.Total());
        }

        [Test]
        public void CanHealDamage()
        {
            Health health = new Health(1);

            health.Heal(2);

            Assert.AreEqual(3, health.Total());
        }

        [Test]
        public void CannotHealZeroDamage()
        {
            Health health = new Health(1);

            health.Heal(0);

            Assert.AreEqual(1, health.Total());
        }

        [Test]
        public void CannotHealNegativeDamage()
        {
            Health health = new Health(1);

            health.Heal(-1);

            Assert.AreEqual(1, health.Total());
        }

        [Test]
        public void CanHealAfterLethal()
        {
            Health health = new Health(1);

            health.Damage(2);
            health.Heal(2);

            Assert.AreEqual(1, health.Total());
        }

        [Test]
        public void IsDepletedReturnsFalseWhenNotEmpty()
        {
            Health health = new Health(1);

            Assert.AreEqual(false, health.IsDepleted());
        }

        [Test]
        public void IsDepletedReturnsTrueWhenAtZero()
        {
            Health health = new Health(0);

            Assert.AreEqual(true, health.IsDepleted());
        }

        [Test]
        public void IsDepeltedReturnsTrueWhenAtNegative()
        {
            Health health = new Health(-1);

            Assert.AreEqual(true, health.IsDepleted());
        }

        [Test]
        public void CanSufferLethalDamage()
        {
            Health health = new Health(3);

            health.Damage(4);

            Assert.AreEqual(-1, health.Total());
            Assert.AreEqual(true, health.IsDepleted());
        }

        [Test]
        public void HealthCanChangeBetweenStates()
        {
            Health health = new Health(1);

            health.Damage(1);

            Assert.AreEqual(0, health.Total());
            Assert.AreEqual(true, health.IsDepleted());

            health.Heal(2);

            Assert.AreEqual(2, health.Total());
            Assert.AreEqual(false, health.IsDepleted());
        }
    }
}
