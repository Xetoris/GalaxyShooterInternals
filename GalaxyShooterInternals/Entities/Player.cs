using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Utility;

namespace GalaxyShooterInternals.Entities
{
    /// <summary>
    /// 	Our game's implementation of IPlayer.
    /// </summary>
    public class Player : IArmable, IDamageable, IShieldable, ISpeedable
    {
        /// <summary>
        /// 	The default speed for a player.
        /// </summary>
        private readonly float _defaultSpeed;

        /// <summary>
        /// 	The default weapon for a player.
        /// </summary>
        private readonly IWeapon _defaultWeapon;

        ///	<summary>
        /// 	Represents the player's total health.
        /// </summary>
        private readonly IHealth _health;

        /// <summary>
        /// 	The player's shield.
        /// </summary>
        private IShield _shield;

        /// <summary>
        /// 	Rate at which our player object moves.
        /// </summary>
        private float _speed;

        /// <summary>
        /// 	The weapon the player currently has.
        /// </summary>
        private IWeapon _weapon;

        /// <summary>
        /// 	Creates a new instance of the player object. All base values set to 
        /// 	  defaults for those that have a default value.
        /// </summary>
        /// <param name="defaultSpeed">
        /// 	The default speed value for our new instance.
        /// </param>
        /// <param name="defaultWeapon">
        /// 	The default <see cref="IWeapon" /> for our new instance.
        /// </param>
        /// <param name="health">
        /// 	The initial <see cref="IHealth" /> for our new instance.
        /// </param>
        /// <param name="shield">
        /// 	The initial <see cref="Shield" /> for our new instance.
        /// </param>
        public Player(float defaultSpeed,
                      IWeapon defaultWeapon,
                      IHealth health,
                      IShield shield = null)
        {
            _defaultSpeed = defaultSpeed;
            _defaultWeapon = defaultWeapon;
            _health = health;
            _shield = shield;
            _speed = _defaultSpeed;
            _weapon = _defaultWeapon;
        }

        /// <inheritdoc />
        public void FireWeapon()
        {
            _weapon.Fire();
        }

        /// <inheritdoc />
        public DamageSummary SufferDamage(int damage)
        {
            var summary = new DamageSummary();

            // If we have a shield, remove it.
            if (_shield != null && _shield.StillAvailable())
            {
                _shield.DamageShield(damage);
            }
            else
            {
                summary.Damaged = true;
                summary.InitialHealth = _health.Total();
                summary.Defeated = _health.Damage(damage);
                summary.RemainingHealth = _health.Total();
            }

            return summary;
        }

        /// <inheritdoc />
        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        /// <inheritdoc />
        public void DefaultWeapon()
        {
            _weapon = _defaultWeapon;
        }

        /// <inheritdoc />
        public void ChangeSpeed(float speed)
        {
            _speed = speed;
        }

        /// <inheritdoc />
        public void MultiplySpeed(float modifier)
        {
            // Player can't move backwards, so ignore if negative value.
            if (modifier < 0)
            {
                return;
            }

            _speed *= modifier;
        }

        /// <inheritdoc />
        public void DefaultSpeed()
        {
            _speed = _defaultSpeed;
        }

        /// <inheritdoc />
        public float CurrentSpeed()
        {
            return _speed;
        }

        /// <inheritdoc />
        public void ApplyShield(IShield shield)
        {
            _shield = shield;
        }

        /// <inheritdoc />
        public void RemoveShield()
        {
            _shield = null;
        }

        /// <inheritdoc />
        public IShield Shield()
        {
            return _shield;
        }
    }
}