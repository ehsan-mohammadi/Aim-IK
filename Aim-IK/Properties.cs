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
        public AxisLimitRotation xLimitRotation;
        public AxisLimitRotation yLimitRotation;
        public AxisLimitRotation zLimitRotation;
    }

    /// <summary>
    /// The rotation class
    /// </summary>
    public class Rotation
    {
        public float xRotation;
        public float yRotation;
        public float zRotation;
    }

    /// <summary>
    /// The chest part class
    /// </summary>
    [Serializable]
    public class ChestPart
    {
        public Transform part;
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
}
