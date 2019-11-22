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
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation
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
                        if (smoothLookAt) // If you checked is smooth option
                            chestPart.part.LookAt2D(new Vector2(smoothTarget.x, smoothTarget.y) - chestPart.positionOffset, chestPart.rotationOffset);
                        else
                            chestPart.part.LookAt2D(new Vector2(target.position.x, target.position.y) - chestPart.positionOffset, chestPart.rotationOffset);
                        
                        chestPart.part.CheckClamp2D(chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if (head.part && target)
            {
                if (smoothLookAt) // If you checked is smooth option
                    head.part.LookAt2D(new Vector2(smoothTarget.x, smoothTarget.y) - head.positionOffset, head.rotationOffset);
                else
                    head.part.LookAt2D(new Vector2(target.position.x, target.position.y) - head.positionOffset, head.rotationOffset);
                
                head.part.CheckClamp2D(head.limitRotation, head.GetRotation());
            }
        }
    }
}
