namespace GalaxyShooterInternals
{
    public interface IPlayer
    {
        /// <summary>
        /// 	Fires the current weapon.
        /// </summary>
        void FireWeapon();

        /// <summary>
        /// 	Handles dealing damage to the player.
        /// </summary>
        /// <param name="damage">
        /// 	The amount of damage to deal to the player.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="DamageSummary"/> representing the damage transaction.
        /// </returns>
        DamageSummary SufferDamage(int damage);

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
        /// 	Change's the sprites speed.
        /// </summary>
        /// <param name="speed">
        /// 	New speed value.
        /// </param>
        void ChangeSpeed(float speed);

        /// <summary>
        /// 	Modifies the current speed by some multiplier value.
        /// </summary>
        /// <param name="modifier">
        /// 	The value to mulitply the current speed by.
        /// </param>
        void MultiplySpeed(float modifier);

        /// <summary>
        /// 	Resets the speed back to its default.
        /// </summary>
        void DefaultSpeed();

        /// <summary>
        /// 	Returns the current speed value.
        /// </summary>
        float CurrentSpeed();

        /// <summary>
        /// 	Sets a shield on the player.
        /// </summary>
        /// <param name="shield">
        /// 	An instance of <see cref="IShield"/> to apply to the player.
        /// </param>
        void ApplyShield(IShield shield);

        /// <summary>
        /// 	Removes the current shield on the player.
        /// </summary>
        void RemoveShield();
    }
}