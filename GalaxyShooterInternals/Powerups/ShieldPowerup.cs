using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class ShieldPowerup : IPowerup
    {
        /// <summary>
        /// 	The duration of the buff.
        /// </summary>
        private float? _buffDuration;

        /// <summary>
        /// 	The <see cref="IShield" /> instance to apply to the player.
        /// </summary>
        private IShield _shield;

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

        /// <summary>
        /// 	Applies the shield buff to the player.
        /// </summary>
        /// <param name="player">
        /// 	Instance of <see cref="IPlayer"/> we need to apply the buff to.
        /// </param>
        public void Apply(IPlayer player)
        {
            player.ApplyShield(_shield);
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
            player.RemoveShield();
        }
    }

}