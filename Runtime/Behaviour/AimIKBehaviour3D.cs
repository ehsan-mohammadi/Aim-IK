using UnityEngine;

namespace AimIK.Behaviour
{
    using Definition;

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

        protected override void Initialize ()
        {
            
        }

        protected override void Aim ()
        {
            
        }
    }
}