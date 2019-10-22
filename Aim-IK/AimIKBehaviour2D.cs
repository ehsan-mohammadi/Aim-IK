using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour2D : AimIKBehaviourBase
    {
        public Part2D head;
        public Part2D[] chestParts;

        /// <summary>
        /// Check the 2D clamp
        /// </summary>
        /// <param name="part">The input part transform</param>
        /// <param name="limitRotation">The input axis limit rotation</param>
        /// <param name="rotation">The input 2D rotation</param>
        private void CheckClamp(Transform part, AxisLimitRotation limitRotation, float rotation)
        {
            // Clamp (If activate)
            if (limitRotation.active)
                rotation = AimIKFunctions.ClampAngle(part.localEulerAngles.z, limitRotation.min, limitRotation.max);
            else
                rotation = part.localEulerAngles.z;
            
            // Set rotation variables to part rotation
            Vector3 partRotation = new Vector3(part.localEulerAngles.x, part.localEulerAngles.y, rotation);
            part.localEulerAngles = partRotation;
        }

        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        private void LateUpdate()
        {
            // Check the chest parts
            if (chestParts.Length > 0)
            {
                foreach (Part2D chestPart in chestParts)
                {
                    if (chestPart.part && target) // If chest part and target exists
                    {
                        chestPart.part.LookAt2D(new Vector2(target.position.x, target.position.y) - chestPart.offset);
                        CheckClamp(chestPart.part, chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if (head.part && target)
            {
                head.part.LookAt2D(new Vector2(target.position.x, target.position.y) - head.offset);
                CheckClamp(head.part, head.limitRotation, head.GetRotation());
            }
        }
    }
}
