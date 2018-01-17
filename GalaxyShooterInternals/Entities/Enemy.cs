using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Utility;

namespace GalaxyShooterInternals.Entities
{
    /// <summary>
    ///     Our simple enemy logic controller.
    /// </summary>
    public class Enemy : IDamageable, ISpeedable
    {
        /// <summary>
        ///     The default speed for the entity.
        /// </summary>
        private float _defaultSpeed;

        /// <summary>
        ///     The enemy health pool.
        /// </summary>
        private IHealth _health;

        /// <summary>
        ///     The enemy speed value.
        /// </summary>
        private float _speed;


        /// <summary>
        ///     Creates a new instance of the enemy logic controller.
        /// </summary>
        /// <param name="health">
        ///     Instance of <see cref="IHealth"/> for the health pool.
        /// </param>
        /// <param name="speed">
        ///     Float for the enemy speed value.
        /// </param>
        public Enemy(float speed, IHealth health)
        {
            _health = health;
            _defaultSpeed = speed;
            _speed = _defaultSpeed;
        }


        /// <summary>
        /// 	Handles dealing damage to the enemy.
        /// </summary>
        /// <param name="damage">
        /// 	The amount of damage to deal.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="DamageSummary"/> representing the damage transaction.
        /// </returns>
        public DamageSummary SufferDamage(int damage)
        {
            DamageSummary summary = new DamageSummary();

            summary.InitialHealth = _health.Total();
            summary.Damaged = true;
            summary.Defeated = _health.Damage(damage);
            summary.RemainingHealth = _health.Total();

            return summary;
        }

        /// <summary>
        /// 	Returns the current speed value.
        /// </summary>
        public float CurrentSpeed()
        {
            return _speed;
        }

        /// <summary>
        ///     Sets the new speed for the enemy.
        /// </summary>
        /// <param name="speed">
        ///     New value for speed.
        /// </param>
        public void ChangeSpeed(float speed)
        {
            _speed = speed;
        }

        /// <summary>
        ///     Multiplies the speed of the enemy.
        /// </summary>
        /// <param name="modifier">
        ///     Amount to multiply the current speed with.
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
        ///     Resets the speed of the enemy to its initial value.
        /// </summary>
        public void DefaultSpeed()
        {
            _speed = _defaultSpeed;
        }
    }
}