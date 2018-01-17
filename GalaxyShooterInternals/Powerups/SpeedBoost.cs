using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class SpeedBoost : IPowerup<ISpeedable>
    {
        /// <summary>
        /// 	Duration of the power up effect.
        /// </summary>
        private float? _buffDuration;

        /// <summary>
        /// 	Amount we multiply the speed by.
        /// </summary>
        private float _multiplier;

        public SpeedBoost(float? duration = 10f, float multiplier = 1.5f)
        {
            _buffDuration = duration;
            _multiplier = multiplier;
        }

        /// <summary>
        /// 	Applies the speed buff to the player.
        /// </summary>
        /// <param name="target">
        /// 	Instance of <see cref="ISpeedable"/> we need to apply the buff to.
        /// </param>
        public void Apply(ISpeedable target)
        {
            target.MultiplySpeed(_multiplier);
        }

        /// <summary>
        /// 	Returns the duration of the buff.
        /// </summary>
        /// <returns>
        /// 	Float
        /// </returns>
        public float? Duration()
        {
            return _buffDuration;
        }

        /// <summary>
        ///     Returns the string associated with the speed powerup.
        /// </summary>
        /// <returns></returns>
        public string Identifier()
        {
            return Utility.Powerups.SPEED;
        }

        /// <summary>
        /// 	Removes the buff from the player.
        /// </summary>
        /// <param name="target">
        /// 	Instance of <see cref="ISpeedable" /> we need to remove the buff from.
        /// </param>
        public void Remove(ISpeedable target)
        {
            target.DefaultSpeed();
        }
    }

}