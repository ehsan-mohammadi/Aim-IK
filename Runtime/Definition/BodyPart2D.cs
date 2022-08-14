using UnityEngine;
using System;

namespace AimIK.Definition
{
    [Serializable]
    public class BodyPart2D
    {
        public Transform Bone;
        public Vector2 PositionOffset;
        public float RotationOffset;
        public LimitRotationAxis LimitRotation;
        public Gizmos Gizmos;
        public float Rotation { get; set; }
    }
}