namespace GalaxyShooterInternals
{
    /// <summary>
    ///     Interface for a player powerup!
    /// </summary>
    public interface IPowerup
    {
        /// <summary>
        ///     Method to apply the powerup.
        /// </summary>
        /// <param name="target">
        ///     The player logic control to apply the powerup too.
        /// </param>
        void Apply(IPlayer target);

        /// <summary>
        ///     Returns the duration the buff is applied for.
        ///         To be indefinite, can return null or a value less than 1.
        /// </summary>
        /// <returns></returns>
        float? Duration();

        /// <summary>
        ///     Method to remove the powerup.
        /// </summary>
        /// <param name="target">
        ///     The player logic control to remove the powerup from.
        /// </param>
        void Remove(IPlayer target);
    }

}