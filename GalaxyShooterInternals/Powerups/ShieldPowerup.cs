using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class ShieldPowerup : IPowerup<IShieldable>
    {
        /// <summary>
        /// 	The duration of the buff.
        /// </summary>
        private readonly float? _buffDuration;

        /// <summary>
        /// 	The <see cref="IShield" /> instance to apply to the player.
        /// </summary>
        private readonly IShield _shield;

        /// <summary>
        /// 	Creates a new instance of the Shield powerup!
        /// </summary>
        /// <param name="shield">
        ///     Instance of <see cref="IShield"/> to apply to player.
        /// </param>
        /// <param name="duration">
        ///     Duration to apply the buff for.
        /// </param>
        public ShieldPowerup(IShield shield, float? duration = 10f)
        {
            _buffDuration = duration;
            _shield = shield;
        }

        /// <inheritdoc />
        public void Apply(IShieldable target)
        {
            target.ApplyShield(_shield);
        }

        /// <inheritdoc />
        public float? Duration()
        {
            return _buffDuration;
        }

        /// <inheritdoc />
        public string Identifier()
        {
            return Utility.Powerups.Shield;
        }

        /// <inheritdoc />
        public void Remove(IShieldable target)
        {
            target.RemoveShield();
        }
    }

}