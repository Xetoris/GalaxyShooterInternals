using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Utility;

namespace GalaxyShooterInternals.Entities
{
    /// <summary>
    /// 	Our game's implementation of IPlayer.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// 	The default speed for a player.
        /// </summary>
        private float _defaultSpeed;

        /// <summary>
        /// 	The default weapon for a player.
        /// </summary>
        private IWeapon _defaultWeapon;

        ///	<summary>
        /// 	Represents the player's total health.
        /// </summary>
        private IHealth _health;

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

        /// <summary>
        /// 	Fires the current weapon.
        /// </summary>
        public void FireWeapon()
        {
            _weapon.Fire();
        }

        /// <summary>
        /// 	Handles dealing damage to the player.
        /// </summary>
        /// <param name="damage">
        /// 	The amount of damage to deal to the player.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="DamageSummary"/> representing the damage transaction.
        /// </returns>
        public DamageSummary SufferDamage(int damage)
        {
            DamageSummary summary = new DamageSummary();

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

        /// <summary>
        /// 	Applies a new IWeapon.
        /// </summary>
        /// <param name="weapon">
        /// 	The <see cref="IWeapon" /> instance to change to.
        /// </param>
        public void ChangeWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        /// <summary>
        /// 	Resets the weapon back to its default.
        /// </summary>
        public void DefaultWeapon()
        {
            _weapon = _defaultWeapon;
        }

        /// <summary>
        /// 	Change's the sprites speed.
        /// </summary>
        /// <param name="speed">
        /// 	New speed value.
        /// </param>
        public void ChangeSpeed(float speed)
        {
            _speed = speed;
        }

        /// <summary>
        /// 	Modifies the current speed by some multiplier value.
        /// </summary>
        /// <param name="modifier">
        /// 	The value to mulitply the current speed by.
        /// </param>
        public void MultiplySpeed(float modifier)
        {
            // Player can't move backwards, so ignore if negative value.
            if (modifier < 0)
            {
                return;
            }

            _speed *= modifier;
        }

        /// <summary>
        /// 	Resets the speed back to its default.
        /// </summary>
        public void DefaultSpeed()
        {
            _speed = _defaultSpeed;
        }

        /// <summary>
        /// 	Returns the current speed value.
        /// </summary>
        public float CurrentSpeed()
        {
            return _speed;
        }

        /// <summary>
        /// 	Sets a shield on the player.
        /// </summary>
        /// <param name="shield">
        /// 	An instance of <see cref="IShield"/> to apply to the player.
        /// </param>
        public void ApplyShield(IShield shield)
        {
            _shield = shield;
        }

        /// <summary>
        /// 	Removes the current shield on the player.
        /// </summary>
        public void RemoveShield()
        {
            _shield = null;
        }
    }
}