using UnityEngine;

namespace AimIK
{
    [DisallowMultipleComponent]
    public abstract class AimIKBehaviourBase : MonoBehaviour
    {
        public Transform target;
        public bool smoothLookAt;
        public float smoothTime;
        protected Vector3 smoothTarget;

        void Awake()
        {
            if (target)
                smoothTarget = target.position;
            else
                smoothTarget = Vector3.zero;
        }

        void Update()
        {
            // Smooth move to target
            if(target)
                smoothTarget = Vector3.Lerp(smoothTarget, target.position, smoothTime);
        }
    }
}
