using UnityEngine;

namespace AimIK.Behaviour
{
    using Entity;

    [DisallowMultipleComponent]
    public abstract class AimIKBehaviourBase : Unit
    {
        [SerializeField] private Transform target;
        [SerializeField] private bool isSmoothLookAt = false;
        [SerializeField, Range(0f, 1f)] private float smoothTime = 0.1f;
        private Vector3 smoothTarget;

        public Transform Target
        {
            get { return target; }
            set { target = value; }
        }

        public bool IsSmoothLookAt
        {
            get { return isSmoothLookAt; }
            set { isSmoothLookAt = value; }
        }

        public float SmoothTime
        {
            get { return smoothTime; }
            set { smoothTime = value; }
        }

        protected abstract void Aim ();

        private void LateUpdate ()
        {
            Aim();
        }
    }
}