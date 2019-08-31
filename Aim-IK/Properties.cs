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
}
