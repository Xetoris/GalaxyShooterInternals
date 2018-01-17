using GalaxyShooterInternals.Utility;

namespace GalaxyShooterInternals.Interfaces
{
    interface IDamageable
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
    }
}
