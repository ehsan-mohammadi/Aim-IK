using UnityEngine;

namespace AimIK
{
    using Properties;
    using Functions;

    public class AimIKBehaviour : AimIKBehaviourBase
    {
        #region Variables
            [SerializeField]
            private Part head;

            [SerializeField]
            private Part[] chestParts;
        #endregion

        #region SetterGetter
            public Part Head
            {
                get { return head; }
                set { head = value; }
            }

            public Part[] ChestParts
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
            if(chestParts.Length > 0)
            {
                foreach(Part chestPart in chestParts)
                {
                    if(chestPart.part && Target) // If chest part and target exists
                    {
                        if (SmoothLookAt) // If you checked is smooth option
                            chestPart.part.LookAt3D(SmoothTarget - chestPart.positionOffset, chestPart.rotationOffset);
                        else
                            chestPart.part.LookAt3D(Target.position - chestPart.positionOffset, chestPart.rotationOffset);

                        chestPart.part.CheckClamp3D(chestPart.limitRotation, chestPart.GetRotation());
                    }
                }
            }

            // If head and target exists
            if(head.part && Target)
            {
                if (SmoothLookAt) // If you checked is smooth option
                    head.part.LookAt3D(SmoothTarget - head.positionOffset, head.rotationOffset);
                else
                    head.part.LookAt3D(Target.position - head.positionOffset, head.rotationOffset);

                head.part.CheckClamp3D(head.limitRotation, head.GetRotation());
            }
        }
    }
}
