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

        public Vector3 SmoothTarget
        {
            get { return smoothTarget; }
        }

        private void SmoothMovement ()
        {
            if (isSmoothLookAt && target)
                smoothTarget = Vector3.Lerp(smoothTarget, target.position, smoothTime);
        }

        protected abstract void Aim ();
        protected abstract void Gizmos ();

        private void Update ()
        {
            SmoothMovement();
        }

        private void LateUpdate ()
        {
            Aim();
        }

        private void OnDrawGizmos ()
        {
            Gizmos();
        }
    }
}