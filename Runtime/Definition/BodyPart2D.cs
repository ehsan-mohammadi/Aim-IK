using UnityEngine;
using System;

namespace AimIK.Definition
{
    [Serializable]
    public class BodyPart2D
    {
        public Transform Bone;
        public Vector2 PositionOffset;
    }
}