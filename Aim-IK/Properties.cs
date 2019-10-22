using System;
using UnityEngine;

namespace AimIK.Properties
{
    /// <summary>
    /// The axis limit rotation class
    /// </summary>
    [Serializable]
    public class AxisLimitRotation
    {
        public bool active;
        public float min;
        public float max;
    }


    /// <summary>
    /// The limit rotation class
    /// </summary>
    [Serializable]
    public class LimitRotation
    {
        public AxisLimitRotation x;
        public AxisLimitRotation y;
        public AxisLimitRotation z;
    }

    /// <summary>
    /// The rotation class
    /// </summary>
    public class Rotation
    {
        public float x;
        public float y;
        public float z;
    }

    /// <summary>
    /// The Part class
    /// </summary>
    [Serializable]
    public class Part
    {
        public Transform part;
        public Vector3 positionOffset;
        public Vector3 rotationOffset;
        public LimitRotation limitRotation;
        private Rotation rotation = new Rotation();

        /// <summary>
        /// Get the current rotation of the part
        /// </summary>
        /// <returns>The current rotation</returns>
        public Rotation GetRotation()
        {
            return rotation;
        }
    }

    /// <summary>
    /// The 2D part class
    /// </summary>
    [Serializable]
    public class Part2D
    {
        public Transform part;
        public Vector2 positionOffset;
        public float rotationOffset;
        public AxisLimitRotation limitRotation;
        private float rotation;

        /// <summary>
        /// Get the current rotation of the 2D part
        /// </summary>
        /// <returns>The current rotation</returns>
        public float GetRotation()
        {
            return rotation;
        }
    }
}
