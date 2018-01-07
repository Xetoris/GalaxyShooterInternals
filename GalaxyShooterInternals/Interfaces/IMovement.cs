using UnityEngine;

namespace GalaxyShooterInternals
{
    public interface IMovement
    {
        Vector3 GetMoveVector(Vector3 origin, float xInput, float yInput, float changeRate);

        Vector3 GetRandomSpawnPoint(DirectionEnum direction);
    }

}