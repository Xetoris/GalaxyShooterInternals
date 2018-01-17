namespace GalaxyShooterInternals.Interfaces
{
    public interface ISpeedable
    {
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
    }
}
