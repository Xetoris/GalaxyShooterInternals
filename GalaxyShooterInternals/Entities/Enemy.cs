namespace GalaxyShooterInternals
{
    /// <summary>
    ///     Our simple enemy logic controller.
    /// </summary>
    public class Enemy : IEnemy
    {
        /// <summary>
        ///     The enemy health pool.
        /// </summary>
        private IHealth _health;

        /// <summary>
        ///     The enemy speed value.
        /// </summary>
        private float _speed;


        /// <summary>
        ///     Creates a new instance of the enemy logic controller.
        /// </summary>
        /// <param name="health">
        ///     Instance of <see cref="IHealth"/> for the health pool.
        /// </param>
        /// <param name="speed">
        ///     Float for the enemy speed value.
        /// </param>
        public Enemy(float speed, IHealth health)
        {
            _health = health;
            _speed = speed;
        }


        /// <summary>
        /// 	Handles dealing damage to the enemy.
        /// </summary>
        /// <param name="damage">
        /// 	The amount of damage to deal.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="DamageSummary"/> representing the damage transaction.
        /// </returns>
        public DamageSummary SufferDamage(int damage)
        {
            DamageSummary summary = new DamageSummary();

            summary.InitialHealth = _health.Total();
            summary.Damaged = true;
            summary.Defeated = _health.Damage(damage);
            summary.RemainingHealth = _health.Total();

            return summary;
        }

        /// <summary>
        /// 	Returns the current speed value.
        /// </summary>
        public float CurrentSpeed()
        {
            return _speed;
        }
    }
}