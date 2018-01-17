namespace GalaxyShooterInternals.Interfaces
{
    public interface IArmable
    {
        /// <summary>
        /// 	Applies a new IWeapon.
        /// </summary>
        /// <param name="weapon">
        /// 	The <see cref="IWeapon" /> instance to change to.
        /// </param>
        void ChangeWeapon(IWeapon weapon);

        /// <summary>
        /// 	Resets the weapon back to its default.
        /// </summary>
        void DefaultWeapon();

        /// <summary>
        /// 	Fires the current weapon.
        /// </summary>
        void FireWeapon();
    }
}
