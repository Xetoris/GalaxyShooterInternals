using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Shields
{

    /// <summary>
    ///     Our standard shield class for the player ship.
    ///         It only has two states - on / off.
    ///         State is set to off at any damage received.
    /// </summary>
    public class StandardShield : IShield
    {
        /// <summary>
        ///     Tracks shield state - on / off.
        /// </summary>
        private bool _shielded;

        public StandardShield()
        {
            _shielded = true;
        }

        /// <summary>
        ///     Applies damage to the shield.
        /// </summary>
        /// <param name="damage">
        ///     The amount of damage to deal.
        /// </param>
        /// <returns>
        ///     Boolean indicating if the shield has been depleted.
        /// </returns>
        public bool DamageShield(int damage = 1)
        {
            if (_shielded && damage > 0)
            {
                _shielded = false;
            }

            return !_shielded;
        }

        /// <summary>
        ///     Indicate if the shield is still available.
        /// </summary>
        /// <returns>
        ///     Boolean indicating if the shield is still available.
        /// </returns>
        public bool StillAvailable()
        {
            return _shielded;
        }
    }

}