using UnityEngine;
using System;

namespace AimIK.Definition
{
    [Serializable]
    public class BodyPart3D
    {
        public Transform Bone;
        public Vector3 PositionOffset;
        public Vector3 RotationOffset;
        public LimitRotation LimitRotation;
        public Gizmos Gizmos;
        public Vector3 Rotation { get; set; }
    }
}