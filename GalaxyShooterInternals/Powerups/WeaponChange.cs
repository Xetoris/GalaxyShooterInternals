using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class WeaponChange : IPowerup
    {
        /// <summary>
        /// 	Duration of the power up effect.
        /// </summary>
        private float? _buffDuration;

        /// <summary>
        /// 	Weapon upgrade to apply.
        /// </summary>
        private IWeapon _newWeapon;

        /// <summary>
        /// 	Creates a new instance of our weapon buff!
        /// </summary>
        /// <param name="weapon">
        /// 	Weapon to switch to when the buff is applied.
        /// </param>
        /// <param name="duration">
        /// 	Duration of the buff.
        /// </param>
        public WeaponChange(IWeapon weapon, float? duration = 10f)
        {
            _newWeapon = weapon;
            _buffDuration = duration;
        }

        /// <summary>
        /// 	Applies the weapon buff to the player.
        /// </summary>
        /// <param name="player">
        /// 	Instance of <see cref="IPlayer"/> we need to apply the buff to.
        /// </param>
        public void Apply(IPlayer player)
        {
            player.ChangeWeapon(_newWeapon);
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
        ///     Returns the string associated with the tripleshot powerup.
        /// </summary>
        /// <returns></returns>
        public string Identifier()
        {
            return Utility.Powerups.TRIPLESHOT;
        }

        /// <summary>
        /// 	Removes the buff from the player.
        /// </summary>
        /// <param name="player">
        /// 	Instance of <see cref="IPlayer" /> we need to remove the buff from.
        /// </param>
        public void Remove(IPlayer player)
        {
            player.DefaultWeapon();
        }
    }

}