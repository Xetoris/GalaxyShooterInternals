using GalaxyShooterInternals.Utility;

namespace GalaxyShooterInternals.Interfaces
{

    /// <summary>
    ///     Interface for our enemy entities.
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// 	Handles dealing damage to the player.
        /// </summary>
        /// <param name="damage">
        /// 	The amount of damage to deal to the player.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="DamageSummary"/> representing the damage transaction.
        /// </returns>
        DamageSummary SufferDamage(int damage);

        /// <summary>
        /// 	Returns the current speed value.
        /// </summary>
        float CurrentSpeed();
    }
}