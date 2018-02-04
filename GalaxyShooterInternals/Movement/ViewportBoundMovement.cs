using GalaxyShooterInternals.Interfaces;
using GalaxyShooterInternals.Utility;
using System;
using UnityEngine;

namespace GalaxyShooterInternals.Movement
{
    public class ViewportBoundMovement : IMovement
    {
        /// <summary>
        /// 	Instance of <see cref="UnityEngine.Camera"/> used to calculate viewport bound movement.
        /// </summary>
        private readonly Camera _camera;

        /// <summary>
        /// 	A viewport relative value indicating the maximum value for the top of the viewport.
        /// 	By default the upper bound limit is 1f (the top of the visible area).
        /// </summary>
        private readonly float _upperViewportBound;

        /// <summary>
        /// 	A viewport relative value indicating the minimum value for the bottom of the viewport.
        /// 	By default the lower bound limit is 0f (the bottom of the visible area).
        /// </summary>
        private readonly float _lowerViewportBound;

        /// <summary>
        /// 	A viewport relative value indicating the maximum value for the right of the viewport.
        /// 	By default the upper bound limit is 1f (the far right of the visible area).
        /// </summary>
        private readonly float _rightViewportBound;

        /// <summary>
        /// 	A viewport relative value indicating the minimum value for the left of the viewport.
        /// 	By default the lower bound limit is 0f (the far left of the visible area).
        /// </summary>
        private readonly float _leftViewportBound;

        #region Constructors

        /// <summary>
        /// 	Creates a new instance, recording the camera and boundaries for later calculations.
        /// </summary>
        /// <param name="camera">
        /// 	Instance of <see cref="UnityEngine.Camera"/> used to calculate viewport bound movement.
        /// </param>
        /// <param name="upperViewportBound">
        /// 	A viewport relative value indicating the maximum value for the top of the viewport.
        /// 	By default the upper bound limit is 1f (the top of the visible area).
        /// </param>
        /// <param name="lowerViewportBound">
        /// 	A viewport relative value indicating the minimum value for the bottom of the viewport.
        /// 	By default the lower bound limit is 0f (the bottom of the visible area).
        /// </param>
        /// <param name="rightViewportBound">
        /// 	A viewport relative value indicating the maximum value for the right of the viewport.
        /// 	By default the upper bound limit is 1f (the far right of the visible area).
        /// </param>
        /// <param name="leftViewportBound">
        /// 	A viewport relative value indicating the minimum value for the left of the viewport.
        /// 	By default the lower bound limit is 0f (the far left of the visible area).
        /// </param>
        public ViewportBoundMovement(Camera camera,
                                     float upperViewportBound = 1f,
                                     float lowerViewportBound = 0f,
                                     float rightViewportBound = 1f,
                                     float leftViewportBound = 0f)
        {
            _camera = camera;
            _upperViewportBound = upperViewportBound;
            _lowerViewportBound = lowerViewportBound;
            _rightViewportBound = rightViewportBound;
            _leftViewportBound = leftViewportBound;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// 	Returns a relative movement vector based on control input and the camera bounds.
        /// </summary>
        /// <param name="origin">
        /// 	A <see cref="UnityEngine.Vector3"/> instance of the current position in the world.
        /// </param>
        /// <param name="xInput">
        /// 	Indicates the current movement input on the X axis.
        /// 	Values range from -1 (moving left) to 1 (moving right).
        /// </param>
        /// <param name="yInput">
        /// 	Indicates the current movement input on the Y axis.
        /// 	Valused range from -1 (moving down) to 1 (moving up). 
        /// </param>
        /// <param name="changeRate">
        /// 	Indicates how fast the position changes over time.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="UnityEngine.Vector3"/>
        /// </returns> 
        public Vector3 GetMoveVector(Vector3 origin, float xInput, float yInput, float changeRate)
        {
            return GetMoveVector(origin,
                                 xInput,
                                 yInput,
                                 changeRate,
                                 _camera,
                                 _upperViewportBound,
                                 _lowerViewportBound,
                                 _rightViewportBound,
                                 _leftViewportBound);
        }

        /// <summary>
        /// 	Generates a spawn point for the sprite, given the direction it will be moving in.
        /// </summary>
        /// <param name="direction">
        /// 	Value from <see cref="DirectionEnum"/> that indicates the primary direction the sprite will move in.
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="UnityEngine.Vector3"/>
        /// </returns>
        public Vector3 GetRandomSpawnPoint(DirectionEnum direction)
        {
            return GetRandomSpawnPoint(direction,
                                          _camera,
                                      _upperViewportBound,
                                      _lowerViewportBound,
                                      _rightViewportBound,
                                      _leftViewportBound);
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// 	Returns a relative movement vector based on control input and the camera bounds.
        /// </summary>
        /// <param name="origin">
        /// 	A <see cref="UnityEngine.Vector3"/> instance of the current position in the world.
        /// </param>
        /// <param name="xInput">
        /// 	Indicates the current movement input on the X axis.
        /// 	Values range from -1 (moving left) to 1 (moving right).
        /// </param>
        /// <param name="yInput">
        /// 	Indicates the current movement input on the Y axis.
        /// 	Valused range from -1 (moving down) to 1 (moving up). 
        /// </param>
        /// <param name="changeRate">
        /// 	Indicates how fast the position changes over time.
        /// </param>
        /// <param name="camera">
        /// 	Our <see cref="UnityEngine.Camera"/> instance for the viewport.
        /// </param>
        /// <param name="upperViewportBound">
        /// 	A viewport relative value indicating the maximum value for the top of the viewport.
        /// 	By default the upper bound limit is 1f (the top of the visible area).
        /// </param>
        /// <param name="lowerViewportBound">
        /// 	A viewport relative value indicating the minimum value for the bottom of the viewport.
        /// 	By default the lower bound limit is 0f (the bottom of the visible area).
        /// </param>
        /// <param name="rightViewportBound">
        /// 	A viewport relative value indicating the maximum value for the right of the viewport.
        /// 	By default the upper bound limit is 1f (the far right of the visible area).
        /// </param>
        /// <param name="leftViewportBound">
        /// 	A viewport relative value indicating the minimum value for the left of the viewport.
        /// 	By default the lower bound limit is 0f (the far left of the visible area).
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="UnityEngine.Vector3"/>
        /// </returns>
        public static Vector3 GetMoveVector(Vector3 origin,
                                            float xInput,
                                            float yInput,
                                            float changeRate,
                                                 Camera camera,
                                            float upperViewportBound = 1f,
                                             float lowerViewportBound = 0f,
                                             float rightViewportBound = 1f,
                                            float leftViewportBound = 0f)
        {
            var x = xInput;
            var y = yInput;

            var viewPos = camera.WorldToViewportPoint(origin);

            // Check Bounds
            if ((y > 0 && viewPos.y >= upperViewportBound) || (y < 0 && viewPos.y <= lowerViewportBound))
            {
                y = 0;
            }

            if ((x > 0 && viewPos.x >= rightViewportBound) || (x < 0 && viewPos.x <= leftViewportBound))
            {
                x = 0;
            }

            // Return new movement
            return (new Vector3(x, y, 0) * Time.deltaTime * changeRate);
        }


        /// <summary>
        /// 	Generates a spawn point for a sprite, given the direction and the viewport relative bounds.
        /// </summary>
        /// <param name="direction">
        /// 	Value from <see cref="DirectionEnum"/> that indicates the primary direction the sprite will move in.
        /// </param>
        /// <param name="camera">
        /// 	Our <see cref="UnityEngine.Camera"/> instance for the viewport.
        /// </param>
        /// <param name="upperViewportBound">
        /// 	A viewport relative value indicating the maximum value for the top of the viewport.
        /// 	By default the upper bound limit is 1f (the top of the visible area).
        /// </param>
        /// <param name="lowerViewportBound">
        /// 	A viewport relative value indicating the minimum value for the bottom of the viewport.
        /// 	By default the lower bound limit is 0f (the bottom of the visible area).
        /// </param>
        /// <param name="rightViewportBound">
        /// 	A viewport relative value indicating the maximum value for the right of the viewport.
        /// 	By default the upper bound limit is 1f (the far right of the visible area).
        /// </param>
        /// <param name="leftViewportBound">
        /// 	A viewport relative value indicating the minimum value for the left of the viewport.
        /// 	By default the lower bound limit is 0f (the far left of the visible area).
        /// </param>
        /// <returns>
        /// 	An instance of <see cref="UnityEngine.Vector3"/>
        /// </returns>
        public static Vector3 GetRandomSpawnPoint(DirectionEnum direction,
                                                  Camera camera,
                                                  float upperViewportBound = 1f,
                                                   float lowerViewportBound = 0f,
                                                   float rightViewportBound = 1f,
                                                  float leftViewportBound = 0f)
        {
            var vector = new Vector3(0, 0, 0);
            var z = Math.Abs(camera.transform.position.z);

            switch (direction)
            {
                case DirectionEnum.Left:
                    var y = UnityEngine.Random.Range(lowerViewportBound + .2f, upperViewportBound - .2f);
                    vector.Set(rightViewportBound, y, z);
                    break;
                default:
                    var x = UnityEngine.Random.Range(leftViewportBound + .2f, rightViewportBound - .2f);
                    vector.Set(x, upperViewportBound, z);
                    break;
            }

            return camera.ViewportToWorldPoint(vector);
        }

        #endregion
    }
}
