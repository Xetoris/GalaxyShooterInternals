using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class SpeedBoost : IPowerup<ISpeedable>
    {
        /// <summary>
        /// 	Duration of the power up effect.
        /// </summary>
        private readonly float? _buffDuration;

        /// <summary>
        /// 	Amount we multiply the speed by.
        /// </summary>
        private readonly float _multiplier;

        public SpeedBoost(float? duration = 10f, float multiplier = 1.5f)
        {
            _buffDuration = duration;
            _multiplier = multiplier;
        }

        /// <inheritdoc />
        public void Apply(ISpeedable target)
        {
            target.MultiplySpeed(_multiplier);
        }

        /// <inheritdoc />
        public float? Duration()
        {
            return _buffDuration;
        }

        /// <inheritdoc />
        public string Identifier()
        {
            return Utility.Powerups.Speed;
        }

        /// <inheritdoc />
        public void Remove(ISpeedable target)
        {
            target.DefaultSpeed();
        }
    }

}