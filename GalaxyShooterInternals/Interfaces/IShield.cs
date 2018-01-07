namespace GalaxyShooterInternals
{
    /// <summary>
    ///     The shield interface for player shields.
    /// </summary>
    public interface IShield
    {
        /// <summary>
        ///     Should apply the given damage to a shield.
        /// </summary>
        /// <param name="damage">
        ///     The amount of damage to apply.
        /// </param>
        /// <returns>
        ///     Boolean indicating if the shield has been spent.
        /// </returns>
        bool DamageShield(int damage);

        /// <summary>
        ///     Indicates if the shield is still available.
        /// </summary>
        /// <returns>
        ///     Boolean
        /// </returns>
        bool StillAvailable();
    }
}