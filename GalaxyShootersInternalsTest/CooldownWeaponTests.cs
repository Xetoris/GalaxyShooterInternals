using GalaxyShooterInternals;
using NUnit.Framework;
using NSubstitute;

namespace GalaxyShootersInternalsTest
{
    public class TestCooldownWeapon : CooldownWeapon
    {
        public bool WeaponFired { get; private set; }
        public int TimesFired { get; private set; }

        public TestCooldownWeapon(ITimeProvider provider,
                                  float cooldown = 0.25f,
                                  bool startOnCooldown = false) : base(provider, cooldown, startOnCooldown) {
            WeaponFired = false;
            TimesFired = 0;
        }

        protected override void FireWeapon() {
            WeaponFired = true;
            TimesFired++;
        }
    }

    [TestFixture]
    public class CooldownWeaponTests
    {
        [Test]
        public void CooldownWeaponCanBeInstantiated()
        {
            var timer = GetTimer();

            TestCooldownWeapon weapon = new TestCooldownWeapon(timer);

            weapon.Fire();

            Assert.IsTrue(weapon.WeaponFired);
        }

        [Test]
        public void CanBeInstantiatedOnCooldown()
        {
            var timer = GetTimer();

            TestCooldownWeapon weapon = new TestCooldownWeapon(timer, 5f, true);

            weapon.Fire();

            Assert.IsFalse(weapon.WeaponFired);
        }

        [Test]
        public void CanBeFiredOffCooldown()
        {
            var timer = GetTimer();

            TestCooldownWeapon weapon = new TestCooldownWeapon(timer);

            weapon.Fire();

            Assert.IsTrue(weapon.WeaponFired);
            Assert.AreEqual(1, weapon.TimesFired);
        }

        [Test]
        public void GoesOnCooldownWhenFired()
        {
            var timer = GetTimer();

            TestCooldownWeapon weapon = new TestCooldownWeapon(timer, 6f, false);

            // Should Fire
            weapon.Fire();

            // Should Not
            weapon.Fire();

            Assert.IsTrue(weapon.WeaponFired);
            Assert.AreEqual(1, weapon.TimesFired);
        }

        [Test]
        public void CanBeFiredMultipleTimesAroundCooldown()
        {
            var timer = GetTimer();

            TestCooldownWeapon weapon = new TestCooldownWeapon(timer, 3f, false);

            // Should Fire
            weapon.Fire();

            // Should Also Fire
            weapon.Fire();

            Assert.IsTrue(weapon.WeaponFired);
            Assert.AreEqual(2, weapon.TimesFired);
        }









        /// <summary>
        ///     Creates a subtitute for <see cref="ITimeProvider"/> that returns the times 1f, 5f, 10f
        /// </summary>
        /// <param name="times">
        ///     Array of times to return.
        /// </param>
        /// <returns>
        ///     Instance of <see cref="ITimeProvider"/>
        /// </returns>
        private ITimeProvider GetTimer()
        {
            var timer = Substitute.For<ITimeProvider>();

            timer.CurrentTime().Returns(1f, 5f, 10f);

            return timer;
        }
    }
}
