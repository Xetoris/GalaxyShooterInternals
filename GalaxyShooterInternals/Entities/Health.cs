using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Entities
{
    /// <summary>
    ///     Our basic health pool implementation.
    /// </summary>
    public class Health : IHealth
    {
        /// <summary>
        ///     Represents how much health this entity has.
        /// </summary>
        private int _health;

        /// <summary>
        ///     Creates a new health tracker for the given entity.
        /// </summary>
        /// <param name="startHealth">
        ///     The initial amount of health to start with.
        ///     Defaults to 3.
        /// </param>
        public Health(int startHealth = 3)
        {
            _health = startHealth;
        }

        /// <summary>
        ///     Deals damage to the health pool.
        /// </summary>
        /// <param name="amount">
        ///     The amount of damage to deal.
        /// </param>
        /// <returns>
        ///     Boolean indicating if the pool is empty.
        /// </returns>
        public bool Damage(int amount)
        {
            // Nothing to do if you deal less than 1 damage.
            if (amount < 1)
            {
                return false;
            }

            var initial = _health;
            _health -= amount;

            return IsDepleted();
        }

        /// <summary>
        ///     Adds health back to the health pool.
        /// </summary>
        /// <param name="amount">
        ///     The amount of health to restore.
        /// </param>
        public void Heal(int amount)
        {
            // You can't negatively heal, so just return if value is less or equal to zero.
            if (amount < 1)
            {
                return;
            }

            var initial = _health;
            _health += amount;
        }

        /// <summary>
        ///     Gets the current amount of health in the pool.
        /// </summary>
        /// <returns>
        ///     Amount of health available in the pool.
        /// </returns>
        public int Total()
        {
            return _health;
        }

        /// <summary>
        ///     Indicates if the pool is empty.
        /// </summary>
        /// <returns>
        ///     Boolean indicating if the pool is empty.
        /// </returns>
        public bool IsDepleted()
        {
            return _health <= 0;
        }
    }
}