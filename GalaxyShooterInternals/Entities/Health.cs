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

        /// <inheritdoc />
        public bool Damage(int amount)
        {
            // Nothing to do if you deal less than 1 damage.
            if (amount < 1)
            {
                return false;
            }

            _health -= amount;

            return IsDepleted();
        }

        /// <inheritdoc />
        public void Heal(int amount)
        {
            // You can't negatively heal, so just return if value is less or equal to zero.
            if (amount < 1)
            {
                return;
            }

            _health += amount;
        }

        /// <inheritdoc />
        public int Total()
        {
            return _health;
        }

        /// <inheritdoc />
        public bool IsDepleted()
        {
            return _health <= 0;
        }
    }
}