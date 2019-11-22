using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour : AimIKBehaviourBase
    {
        public Part head;
        public Part[] chestParts;
        
        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation
        /// </summary>
        private void LateUpdate()
        {
            // Check the chest parts
            if(chestParts.Length > 0)
            {
                foreach(Part chestPart in chestParts)
                {
                    if(chestPart.part && target) // If chest part and target exists
                    {
                        if (smoothLookAt) // If you checked is smooth option
                            chestPart.part.LookAt3D(smoothTarget - chestPart.positionOffset, chestPart.rotationOffset);
                        else
                            chestPart.part.LookAt3D(target.position - chestPart.positionOffset, chestPart.rotationOffset);

                        chestPart.part.CheckClamp3D(chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if(head.part && target)
            {
                if (smoothLookAt) // If you checked is smooth option
                    head.part.LookAt3D(smoothTarget - head.positionOffset, head.rotationOffset);
                else
                    head.part.LookAt3D(target.position - head.positionOffset, head.rotationOffset);

                head.part.CheckClamp3D(head.limitRotation, head.GetRotation());
            }
        }
    }
}
