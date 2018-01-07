namespace GalaxyShooterInternals
{

    /// <summary>
    ///     Utility data object for sumarizing damage report.
    /// </summary>
    public class DamageSummary
    {
        /// <summary>
        ///     Indicates if damage was dealt.
        ///       Could be false for situations like a shielded hit.
        /// </summary>
        public bool Damaged { get; set; }

        /// <summary>
        ///     Indicates if the damage dealt was leathal.
        /// </summary>
        public bool Defeated { get; set; }

        /// <summary>
        ///     Specifies the health before the damage.
        /// </summary>
        public int? InitialHealth { get; set; }

        /// <summary>
        ///     Specifies the health after the damage.
        /// </summary>
        public int? RemainingHealth { get; set; }

        /// <summary>
        ///     Creates a new empty instance of DamageSummary.
        /// </summary>
        public DamageSummary()
        {
            Damaged = false;
            Defeated = false;
            InitialHealth = null;
            RemainingHealth = null;
        }

    }

}