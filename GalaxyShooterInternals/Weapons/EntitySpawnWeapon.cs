using UnityEngine;

namespace GalaxyShooterInternals
{

    /// <summary>
    ///     A weapon that spawns an object when fired.
    /// </summary>
    public class EntitySpawnWeapon : CooldownWeapon
    {
        /// <summary>
        ///     The object we should spawn when we fire.
        /// </summary>
        protected GameObject _spawnObject;

        /// <summary>
        ///     The object firing the weapon.
        /// </summary>
        protected GameObject _fireObject;

        public EntitySpawnWeapon(GameObject spawnObject,
                                 GameObject fireObject,
                                 ITimeProvider timer,
                                 float cooldown = 0.25f,
                                 bool startOnCooldown = false) : base(timer, cooldown, startOnCooldown)
        {
            _spawnObject = spawnObject;
            _fireObject = fireObject;
        }

        /// <summary>
        ///     Fires the weapon by spawning the game object for the projectile.
        /// </summary>
        public override void FireWeapon()
        {
            var firePosition = _fireObject.transform.position;
            GameObject.Instantiate(_spawnObject, (firePosition + new Vector3(0, .7f, 0)), Quaternion.identity);
        }
    }

}