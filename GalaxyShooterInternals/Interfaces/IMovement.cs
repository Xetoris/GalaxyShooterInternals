using GalaxyShooterInternals.Utility;
using UnityEngine;

namespace GalaxyShooterInternals.Interfaces
{
    public interface IMovement
    {
        Vector3 GetMoveVector(Vector3 origin, float xInput, float yInput, float changeRate);

        Vector3 GetRandomSpawnPoint(DirectionEnum direction);
    }

}