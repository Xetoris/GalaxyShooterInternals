using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Powerups
{

    public class WeaponChange : IPowerup<IArmable>
    {
        /// <summary>
        /// 	Duration of the power up effect.
        /// </summary>
        private readonly float? _buffDuration;

        /// <summary>
        /// 	Weapon upgrade to apply.
        /// </summary>
        private readonly IWeapon _newWeapon;

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

        /// <inheritdoc />
        public void Apply(IArmable target)
        {
            target.ChangeWeapon(_newWeapon);
        }

        /// <inheritdoc />
        public float? Duration()
        {
            return _buffDuration;
        }

        /// <inheritdoc />
        public string Identifier()
        {
            return Utility.Powerups.Tripleshot;
        }

        /// <inheritdoc />
        public void Remove(IArmable target)
        {
            target.DefaultWeapon();
        }
    }

}