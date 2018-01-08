namespace GalaxyShooterInternals.Interfaces
{

    /// <summary>
    ///     An interface for providing the current time.
    ///         I know this is a silly interface, but it will make testing
    ///         time based logic easier by injecting the time tracker.
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        ///     Returns the current game time expressed as a float.
        /// </summary>
        /// <returns>
        ///     Float
        /// </returns>
        float CurrentTime();
    }

}