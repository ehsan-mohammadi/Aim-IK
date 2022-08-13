using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour2D : AimIKBehaviourBase
    {
        #region Variables
            [SerializeField]
            private Part2D head;

            [SerializeField]
            private Part2D[] chestParts;
        #endregion

        #region SetterGetter
            public Part2D Head
            {
                get { return head; }
                set { head = value; }
            }

            public Part2D[] ChestParts
            {
                get { return chestParts; }
                set { chestParts = value; }
            }
        #endregion

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
                    if (chestPart.part && Target) // If chest part and target exists
                    {
                        if (SmoothLookAt) // If you checked is smooth option
                            chestPart.part.LookAt2D(new Vector2(SmoothTarget.x, SmoothTarget.y) - chestPart.positionOffset, chestPart.rotationOffset);
                        else
                            chestPart.part.LookAt2D(new Vector2(Target.position.x, Target.position.y) - chestPart.positionOffset, chestPart.rotationOffset);
                        
                        chestPart.part.CheckClamp2D(chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if (head.part && Target)
            {
                if (SmoothLookAt) // If you checked is smooth option
                    head.part.LookAt2D(new Vector2(SmoothTarget.x, SmoothTarget.y) - head.positionOffset, head.rotationOffset);
                else
                    head.part.LookAt2D(new Vector2(Target.position.x, Target.position.y) - head.positionOffset, head.rotationOffset);
                
                head.part.CheckClamp2D(head.limitRotation, head.GetRotation());
            }
        }
    }
}
