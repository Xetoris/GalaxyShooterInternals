using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalaxyShooterInternals
{

    public class SpeedBoost : IPowerup
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
        /// <param name="player">
        /// 	Instance of <see cref="IPlayer"/> we need to apply the buff to.
        /// </param>
        public void Apply(IPlayer player)
        {
            player.MultiplySpeed(_multiplier);
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
        /// 	Removes the buff from the player.
        /// </summary>
        /// <param name="player">
        /// 	Instance of <see cref="IPlayer" /> we need to remove the buff from.
        /// </param>
        public void Remove(IPlayer player)
        {
            player.DefaultSpeed();
        }
    }

}