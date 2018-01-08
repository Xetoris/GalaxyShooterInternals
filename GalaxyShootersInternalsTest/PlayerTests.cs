using GalaxyShooterInternals.Entities;
using GalaxyShooterInternals.Interfaces;
using NSubstitute;
using NUnit.Framework;


namespace GalaxyShootersInternalsTest
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void CanInstantiatePlayer()
        {
            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            Assert.NotNull(player);
        }

        #region Player Speed

        [Test]
        public void SpeedInitializedCorrectly()
        {
            Player player = new Player(10f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());


            Assert.AreEqual(10f, player.CurrentSpeed());
        }

        [Test]
        public void SpeedSettable()
        {
            Player player = new Player(10f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.ChangeSpeed(20f);

            Assert.AreNotEqual(10f, player.CurrentSpeed());
            Assert.AreEqual(20f, player.CurrentSpeed());
        }

        [Test]
        public void SpeedMultiplyable()
        {
            Player player = new Player(10f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.MultiplySpeed(2f);

            Assert.AreNotEqual(10f, player.CurrentSpeed());
            Assert.AreEqual(20f, player.CurrentSpeed());
        }

        [Test]
        public void NegativeSpeedMultiplierNotApplied()
        {
            var player = new Player(10f,
                                    Substitute.For<IWeapon>(),
                                    Substitute.For<IHealth>());

            player.MultiplySpeed(-1);

            Assert.AreEqual(10f, player.CurrentSpeed());
        }

        [Test]
        public void SpeedCanBeResetOnceSet()
        {
            Player player = new Player(10f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.ChangeSpeed(25f);
            Assert.AreEqual(25f, player.CurrentSpeed());

            player.DefaultSpeed();
            Assert.AreEqual(10f, player.CurrentSpeed());
        }

        [Test]
        public void SpeedCanBeResetOnceMulitplied()
        {
            Player player = new Player(10f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.MultiplySpeed(2f);
            Assert.AreEqual(20f, player.CurrentSpeed());

            player.DefaultSpeed();
            Assert.AreEqual(10f, player.CurrentSpeed());
        }

        #endregion

        #region Weapons Management

        [Test]
        public void WeaponInitializedCorrectly()
        {
            var weapon = Substitute.For<IWeapon>();

            Player player = new Player(0f,
                                       weapon,
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.FireWeapon();

            weapon.Received().Fire();
        }

        [Test]
        public void WeaponSetable()
        {
            var weapon = Substitute.For<IWeapon>();
            var weapon2 = Substitute.For<IWeapon>();

            Player player = new Player(0f,
                                       weapon,
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.ChangeWeapon(weapon2);

            player.FireWeapon();

            weapon2.Received().Fire();
            weapon.DidNotReceive().Fire();
        }

        [Test]
        public void WeaponCanBeResetOnceSet()
        {
            var weapon = Substitute.For<IWeapon>();
            var weapon2 = Substitute.For<IWeapon>();

            Player player = new Player(0f,
                                       weapon,
                                       Substitute.For<IHealth>(),
                                       Substitute.For<IShield>());

            player.ChangeWeapon(weapon2);

            player.DefaultWeapon();

            player.FireWeapon();

            weapon.Received().Fire();
            weapon2.DidNotReceive().Fire();
        }

        #endregion

        #region Health Management

        [Test]
        public void HealthInitializedCorrectly()
        {
            var health = Substitute.For<IHealth>();

            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       health,
                                       Substitute.For<IShield>());


            player.SufferDamage(1);

            health.ReceivedWithAnyArgs().Damage(1);
        }

        [Test]
        public void HealthMethodsCalledCorrectly()
        {
            var health = Substitute.For<IHealth>();
            var damage = 1;

            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       health,
                                       Substitute.For<IShield>());


            player.SufferDamage(damage);

            health.Received(2).Total();
            health.Received().Damage(damage);
        }

        #endregion

        #region Shield Management

        [Test]
        public void ShieldIninitializedCorrectly()
        {
            var shield = GetShieldInstance();

            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       shield);

            player.SufferDamage(1);

            shield.Received().StillAvailable();
        }

        [Test]
        public void ShieldMethodsInvokedCorrectly()
        {
            var shield = GetShieldInstance();
            shield.StillAvailable().Returns(true);

            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       shield);

            player.SufferDamage(1);

            shield.Received().StillAvailable();
            shield.Received().DamageShield(1);
        }

        [Test]
        public void ShieldNotDamagedWhenEmpty()
        {
            var shield = GetShieldInstance();

            shield.StillAvailable().Returns(true, false);

            Player player = new Player(0f,
                                        Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>(),
                                       shield);


            player.SufferDamage(1);
            player.SufferDamage(1);

            shield.Received(2).StillAvailable();
            shield.Received(1).DamageShield(1);
        }

        [Test]
        public void ShieldCanBeSet()
        {
            var shield = GetShieldInstance();

            shield.StillAvailable().Returns(true);

            Player player = new Player(0f,
                                       Substitute.For<IWeapon>(),
                                       Substitute.For<IHealth>());

            player.ApplyShield(shield);

            player.SufferDamage(1);

            shield.Received().StillAvailable();
            shield.Received().DamageShield(1);
        }

        #endregion

        /// <summary>
        ///     Gets a subsitute for <see cref="IShield"/> with mock default behavior.
        /// </summary>
        /// <returns>
        ///     Mock instance of <see cref="IShield"/>.
        /// </returns>
        private IShield GetShieldInstance()
        {
            var shield = Substitute.For<IShield>();
            shield.StillAvailable().Returns(true, false);

            return shield;
        }
    }
}
