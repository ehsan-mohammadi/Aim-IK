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

        private Rotation headRotation = new Rotation();

        public ChestPart[] chestParts;

        /// <summary>
        /// Check the clamp
        /// </summary>
        /// <param name="part">The input part transform</param>
        /// <param name="limitRotation">The input limit rotation</param>
        /// <param name="rotation">The input rotation</param>
        private void CheckClamp(Transform part, LimitRotation limitRotation, Rotation rotation)
        {
            // Clamp (If activate)
            if (limitRotation.xLimitRotation.active)
                rotation.xRotation = AimIKFunctions.ClampAngle(part.localEulerAngles.x, limitRotation.xLimitRotation.min, limitRotation.xLimitRotation.max);
            else
                rotation.xRotation = part.localEulerAngles.x;

            if (limitRotation.yLimitRotation.active)
                rotation.yRotation = AimIKFunctions.ClampAngle(part.localEulerAngles.y, limitRotation.yLimitRotation.min, limitRotation.yLimitRotation.max);
            else
                rotation.yRotation = part.localEulerAngles.y;

            if (limitRotation.zLimitRotation.active)
                rotation.zRotation = AimIKFunctions.ClampAngle(part.localEulerAngles.z, limitRotation.zLimitRotation.min, limitRotation.zLimitRotation.max);
            else
                rotation.zRotation = part.localEulerAngles.z;

            // Set rotation variables to head rotation
            Vector3 partRotation = new Vector3(rotation.xRotation, rotation.yRotation, rotation.zRotation);
            part.localEulerAngles = partRotation;
        }
        
        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        private void LateUpdate()
        {
            // Check the chest parts
            if(chestParts.Length > 0)
            {
                foreach(ChestPart chestPart in chestParts)
                {
                    if(chestPart.part && target) // If chest part and target exists
                    {
                        chestPart.part.LookAt(target.position);
                        CheckClamp(chestPart.part, chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if(head && target)
            {
                head.LookAt(target.position - eyesOffset);
                CheckClamp(head, headLimitRotation, headRotation);
            }
        }
    }
}
