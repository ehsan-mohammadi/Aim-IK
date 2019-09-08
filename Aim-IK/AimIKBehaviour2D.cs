using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour2D : AimIKBehaviourBase
    {
        public Vector2 eyesOffset;

        public AxisLimitRotation headLimitRotation;

        private float headRotation;

        public ChestPart2D[] chestParts;

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
        /// Rotates the 2D transforms so the right vector points at worldPosition
        /// </summary>
        /// <param name="transform">The transform that should to look at</param>
        /// <param name="worldPosition">Point to look at</param>
        private void LookAt2D(Transform transform, Vector2 worldPosition)
        {
            Vector2 diff = worldPosition - new Vector2(transform.position.x, transform.position.y);
            diff.Normalize();

            float rotateZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90);
        }

        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        private void LateUpdate()
        {
            // Check the chest parts
            if (chestParts.Length > 0)
            {
                foreach (ChestPart2D chestPart in chestParts)
                {
                    if (chestPart.part && target) // If chest part and target exists
                    {
                        LookAt2D(chestPart.part, new Vector2(target.position.x, target.position.y) - eyesOffset);
                        CheckClamp(chestPart.part, chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if (head && target)
            {
                LookAt2D(head, new Vector2(target.position.x, target.position.y) - eyesOffset);
                CheckClamp(head, headLimitRotation, headRotation);
            }
        }
    }
}
