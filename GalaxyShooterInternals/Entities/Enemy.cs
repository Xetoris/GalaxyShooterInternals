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
        private readonly float _defaultSpeed;

        /// <summary>
        ///     The enemy health pool.
        /// </summary>
        private readonly IHealth _health;

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


        /// <inheritdoc />
        public DamageSummary SufferDamage(int damage)
        {
            return new DamageSummary
            {
                InitialHealth = _health.Total(),
                Damaged = true,
                Defeated = _health.Damage(damage),
                RemainingHealth = _health.Total()
            };;
        }

        /// <inheritdoc />
        public float CurrentSpeed()
        {
            return _speed;
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
    }
}