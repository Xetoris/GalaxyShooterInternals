namespace GalaxyShooterInternals.Interfaces
{
    public interface IShieldable
    {
        /// <summary>
        /// 	Sets a shield on the player.
        /// </summary>
        /// <param name="shield">
        /// 	An instance of <see cref="IShield"/> to apply to the player.
        /// </param>
        void ApplyShield(IShield shield);

        /// <summary>
        /// 	Removes the current shield on the player.
        /// </summary>
        void RemoveShield();

        /// <summary>
        ///     Returns the current shield.
        /// </summary>
        /// <returns>
        ///     An instance of <see cref="IShield"/>
        /// </returns>
        IShield Shield();
    }
}
