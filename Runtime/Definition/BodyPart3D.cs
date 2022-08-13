using UnityEngine;
using System;

namespace AimIK.Definition
{
    [Serializable]
    public class BodyPart3D
    {
        public Transform Bone;
        public Vector3 PositionOffset;
    }
}