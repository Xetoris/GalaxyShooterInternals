using GalaxyShooterInternals.Interfaces;
using UnityEngine;

namespace GalaxyShooterInternals.Entities
{
    /// <summary>
    ///     A binder for getting time from <see cref="UnitEngine.Time"/>
    /// </summary>
    public class GameTimeProvider : ITimeProvider
    {
        
        /// <inheritdoc />
        public float CurrentTime()
        {
            return Time.time;
        }
    }
}