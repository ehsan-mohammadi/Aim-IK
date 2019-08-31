using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour : MonoBehaviour
    {
        public Transform head;
        public Transform target;

        public Vector3 eyesOffset;

        public LimitRotation headLimitRotation;

        private float headRotationX;
        private float headRotationY;
        private float headRotationZ;

        /// <summary>
        /// Check the clamp
        /// </summary>
        private void CheckClamp()
        {
            // Clamp (If activate)
            if (headLimitRotation.xLimitRotation.active)
                headRotationX = AimIKFunctions.ClampAngle(head.localEulerAngles.x, headLimitRotation.xLimitRotation.min, headLimitRotation.xLimitRotation.max);
            else
                headRotationX = head.localEulerAngles.x;

            if (headLimitRotation.yLimitRotation.active)
                headRotationY = AimIKFunctions.ClampAngle(head.localEulerAngles.y, headLimitRotation.yLimitRotation.min, headLimitRotation.yLimitRotation.max);
            else
                headRotationY = head.localEulerAngles.y;

            if (headLimitRotation.zLimitRotation.active)
                headRotationZ = AimIKFunctions.ClampAngle(head.localEulerAngles.z, headLimitRotation.zLimitRotation.min, headLimitRotation.zLimitRotation.max);
            else
                headRotationZ = head.localEulerAngles.z;

            // Set rotation variables to head rotation
            Vector3 headRotation = new Vector3(headRotationX, headRotationY, headRotationZ);
            head.localEulerAngles = headRotation;
        }
        
        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        private void LateUpdate()
        {
            head.LookAt(target.position - eyesOffset);

            CheckClamp();
        }
    }
}
