using UnityEngine;

namespace AimIK.Behaviour
{
    using Definition;
    using Utility;

    public class AimIKBehaviour2D : AimIKBehaviourBase
    {
        [SerializeField] private BodyPart2D head;
        [SerializeField] private BodyPart2D[] spines;

        public BodyPart2D Head
        {
            get { return head; }
        }

        public BodyPart2D[] Spines
        {
            get { return spines; }
        }

        protected override void Initialize () { }

        protected override void Aim ()
        {
            if (spines.Length > 0)
            {
                foreach (BodyPart2D spine in spines)
                {
                    if (spine.Bone && Target)
                    {
                        if (IsSmoothLookAt)
                            spine.Bone.LookAt2D(new Vector2(SmoothTarget.x, SmoothTarget.y)
                                - spine.PositionOffset, spine.RotationOffset);
                        else
                            spine.Bone.LookAt2D(new Vector2(Target.position.x, Target.position.y)
                                - spine.PositionOffset, spine.RotationOffset);
                        spine.Bone.CheckClamp2D(spine.LimitRotation, spine.Rotation);
                    }
                }
            }

            if (head.Bone && Target)
            {
                if (IsSmoothLookAt)
                    head.Bone.LookAt2D(new Vector2(SmoothTarget.x, SmoothTarget.y)
                        - head.PositionOffset, head.RotationOffset);
                else
                    head.Bone.LookAt2D(new Vector2(Target.position.x, Target.position.y)
                        - head.PositionOffset, head.RotationOffset);

                head.Bone.CheckClamp2D(head.LimitRotation, head.Rotation);
            }
        }

        protected override void Gizmos ()
        {
            #if UNITY_EDITOR
            
            if (head.Bone && Target && head.Gizmos.IsShow)
            {
                UnityEngine.Gizmos.color = head.Gizmos.Color;
                UnityEngine.Gizmos.DrawLine(new Vector2(head.Bone.position.x
                    , head.Bone.position.y) + head.PositionOffset, Target.position);
            }

            if (spines != null)
            {
                foreach (BodyPart2D spine in spines)
                {
                    if (spine.Bone && Target && spine.Gizmos.IsShow)
                    {
                        UnityEngine.Gizmos.color = spine.Gizmos.Color;
                        UnityEngine.Gizmos.DrawLine(new Vector2(spine.Bone.position.x
                            , spine.Bone.position.y)+ spine.PositionOffset, Target.position);
                    }
                }
            }

            #endif
        }
    }
}