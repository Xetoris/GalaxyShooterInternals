using GalaxyShooterInternals.Interfaces;
using UnityEngine;

namespace GalaxyShooterInternals.Weapons
{

    /// <summary>
    ///     A weapon that spawns an object when fired.
    /// </summary>
    public class EntitySpawnWeapon : CooldownWeapon
    {
        /// <summary>
        ///     The object we should spawn when we fire.
        /// </summary>
        private readonly GameObject _spawnObject;

        /// <summary>
        ///     The object firing the weapon.
        /// </summary>
        private readonly GameObject _fireObject;

        /// <summary>
        ///     Creates a new weapon that spawns an entity when fired.
        /// </summary>
        /// <param name="spawnObject">Object that fired the weapon. Used for spawn location calculation.</param>
        /// <param name="fireObject">Object that is spawned when fired.</param>
        /// <param name="timer">Object used to get the current time.</param>
        /// <param name="cooldown">How long to wait till it can be fired again.</param>
        /// <param name="startOnCooldown">Indicates if the weapon should start on cooldown.</param>
        public EntitySpawnWeapon(GameObject spawnObject,
                                 GameObject fireObject,
                                 ITimeProvider timer,
                                 float cooldown = 0.25f,
                                 bool startOnCooldown = false) : base(timer, cooldown, startOnCooldown)
        {
            _spawnObject = spawnObject;
            _fireObject = fireObject;
        }

        /// <inheritdoc />
        protected override void FireWeapon()
        {
            var firePosition = _fireObject.transform.position;
            GameObject.Instantiate(_spawnObject, (firePosition + new Vector3(0, .7f, 0)), Quaternion.identity);
        }
    }

}