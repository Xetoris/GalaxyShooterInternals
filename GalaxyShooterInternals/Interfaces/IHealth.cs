namespace GalaxyShooterInternals
{
    /// <summary>
    ///     Interface for a health pool implementation.
    /// </summary>
    public interface IHealth
    {
        /// <summary>
        ///     Deals damage to the health pool.
        /// </summary>
        /// <param name="amount">
        ///     The amount of damage to deal.
        /// </param>
        /// <returns>
        ///     Boolean indicating if the pool is empty.
        /// </returns>
        bool Damage(int amount);

        /// <summary>
        ///     Adds health back to the health pool.
        /// </summary>
        /// <param name="amount">
        ///     The amount of health to restore.
        /// </param>
        void Heal(int amount);

        /// <summary>
        ///     Gets the current amount of health in the pool.
        /// </summary>
        /// <returns>
        ///     Amount of health available in the pool.
        /// </returns>
        int Total();

        /// <summary>
        ///     Indicates if the pool is empty.
        /// </summary>
        /// <returns>
        ///     Boolean indicating if the pool is empty.
        /// </returns>
        bool IsDepleted();
    }
}