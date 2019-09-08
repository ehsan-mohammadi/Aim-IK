using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour : AimIKBehaviourBase
    {
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
            if (limitRotation.x.active)
                rotation.x = AimIKFunctions.ClampAngle(part.localEulerAngles.x, limitRotation.x.min, limitRotation.x.max);
            else
                rotation.x = part.localEulerAngles.x;

            if (limitRotation.y.active)
                rotation.y = AimIKFunctions.ClampAngle(part.localEulerAngles.y, limitRotation.y.min, limitRotation.y.max);
            else
                rotation.y = part.localEulerAngles.y;

            if (limitRotation.z.active)
                rotation.z = AimIKFunctions.ClampAngle(part.localEulerAngles.z, limitRotation.z.min, limitRotation.z.max);
            else
                rotation.z = part.localEulerAngles.z;

            // Set rotation variables to head rotation
            Vector3 partRotation = new Vector3(rotation.x, rotation.y, rotation.z);
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
                        chestPart.part.LookAt(target.position - chestPart.offset);
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
