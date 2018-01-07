using UnityEngine;

namespace GalaxyShooterInternals
{
    /// <summary>
    ///     A binder for getting time from <see cref="UnitEngine.Time"/>
    /// </summary>
    public class GameTimeProvider : ITimeProvider
    {
        /// <summary>
        ///     Current value of Time.time
        /// </summary>
        /// <returns>
        ///     Float
        /// </returns>
        public float CurrentTime()
        {
            return Time.time;
        }
    }
}