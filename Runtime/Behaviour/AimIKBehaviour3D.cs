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

        protected override void Gizmos ()
        {
            #if UNITY_EDITOR
            
            if (head.Bone && Target && head.Gizmos.IsShow)
            {
                UnityEngine.Gizmos.color = head.Gizmos.Color;
                UnityEngine.Gizmos.DrawLine(head.Bone.position 
                    + head.PositionOffset, Target.position);
            }

            if (spines != null)
            {
                foreach (BodyPart3D spine in spines)
                {
                    if (spine.Bone && Target && spine.Gizmos.IsShow)
                    {
                        UnityEngine.Gizmos.color = spine.Gizmos.Color;
                        UnityEngine.Gizmos.DrawLine(spine.Bone.position 
                            + spine.PositionOffset, Target.position);
                    }
                }
            }

            #endif
        }
    }
}