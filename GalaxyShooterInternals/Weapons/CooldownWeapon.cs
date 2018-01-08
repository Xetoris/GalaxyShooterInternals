using GalaxyShooterInternals.Interfaces;

namespace GalaxyShooterInternals.Weapons
{

    /// <summary>
    ///     A base weapon implementation for a weapon with a recharge time.
    /// </summary>
    public abstract class CooldownWeapon : IWeapon
    {
        /// <summary>
        ///     The amount of time to pass before the weapon is usable again.
        /// </summary>
        private float _cooldown;

        /// <summary>
        ///     The time we must reach before firing again.
        /// </summary>
        private float? _delayUntil;

        /// <summary>
        ///     Object used to track game time.
        /// </summary>
        private ITimeProvider _timer;

        public CooldownWeapon(ITimeProvider timer,
                              float cooldown = 0.25f,
                              bool startOnCooldown = false)
        {
            _timer = timer;
            _cooldown = cooldown;

            // Check if we need to set initial cooldown time.        
            _delayUntil = startOnCooldown ? _timer.CurrentTime() + _cooldown : (float?)null;
        }

        /// <summary>
        ///     Checks if we can fire the weapon.
        /// </summary>
        /// <returns>
        ///     Indicates if the weapon can be fired.
        /// </returns>
        private bool CanFire()
        {
            return (_delayUntil == null || (_timer.CurrentTime() > _delayUntil));
        }

        /// <summary>
        ///     Checks cooldown and calls FireWeapon() if allowed.
        /// </summary>
        public void Fire()
        {
            // If we can't fire, just return.
            //   Is this an acceptable pattern in C#? I know it is in Ruby.
            if (!CanFire())
            {
                return;
            }

            // Fire the weapon.
            FireWeapon();

            // Set the delay.
            _delayUntil = _timer.CurrentTime() + _cooldown;
        }

        /// <summary>
        ///     Logic for actually firing the weapon.
        /// </summary>
        protected abstract void FireWeapon();
    }

}