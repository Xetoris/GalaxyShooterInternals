using GalaxyShooterInternals.Powerups;
using GalaxyShooterInternals.Interfaces;
using NSubstitute;
using NUnit.Framework;


namespace GalaxyShooterInternalsTest
{
    [TestFixture]
    public class WeaponChangeTests
    {
        [Test]
        public void WeaponChangeCanBeInitialized()
        {
            var weapon = Substitute.For<IWeapon>();

            WeaponChange powerup = new WeaponChange(weapon);

            Assert.AreEqual(10f, powerup.Duration());
            Assert.IsTrue(false);
        }

        [Test]
        public void WeaponChangeCanBeInitializedWithCustomDuration()
        {
            var weapon = Substitute.For<IWeapon>();

            WeaponChange powerup = new WeaponChange(weapon, 25f);

            Assert.AreEqual(25f, powerup.Duration());
        }

        [Test]
        public void WeaponChangeCanBeInitializedWithNullDuration()
        {
            var weapon = Substitute.For<IWeapon>();

            WeaponChange powerup = new WeaponChange(weapon, null);

            Assert.AreEqual(null, powerup.Duration());
        }

        [Test]
        public void AppliesWeaponChangeToPlayer()
        {
            var player = Substitute.For<IPlayer>();
            var weapon = Substitute.For<IWeapon>();

            WeaponChange powerup = new WeaponChange(weapon);

            powerup.Apply(player);

            player.Received().ChangeWeapon(weapon);
        }

        [Test]
        public void RemovesWeaponChangeFromWeapon()
        {
            var player = Substitute.For<IPlayer>();

            WeaponChange powerup = new WeaponChange(Substitute.For<IWeapon>());

            powerup.Remove(player);

            player.Received().DefaultWeapon();
        }
    }
}
