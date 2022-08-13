using UnityEngine;

namespace AimIK.Behaviour
{
    using Definition;
    using Utility;

    public class AimIKBehaviour3D : AimIKBehaviourBase
    {
        [SerializeField] private BodyPart3D head;
        [SerializeField] private BodyPart3D[] spines;

        public BodyPart3D Head
        {
            get { return head; }
        }

        public BodyPart3D[] Spines
        {
            get { return spines; }
        }

        protected override void Initialize () { }

        protected override void Aim ()
        {
            if (spines.Length > 0)
            {
                foreach (BodyPart3D spine in spines)
                {
                    if (spine.Bone && Target)
                    {
                        if (IsSmoothLookAt)
                            spine.Bone.LookAt3D(SmoothTarget - spine.PositionOffset
                                , spine.RotationOffset);
                        else
                            spine.Bone.LookAt3D(Target.position - spine.PositionOffset
                                , spine.RotationOffset);
                        spine.Bone.CheckClamp3D(spine.LimitRotation, spine.Rotation);
                    }
                }
            }

            if (head.Bone && Target)
            {
                if (IsSmoothLookAt)
                    head.Bone.LookAt3D(SmoothTarget - head.PositionOffset, head.RotationOffset);
                else
                    head.Bone.LookAt3D(Target.position - head.PositionOffset, head.RotationOffset);

                head.Bone.CheckClamp3D(head.LimitRotation, head.Rotation);
            }
        }
    }
}