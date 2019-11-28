using UnityEngine;

namespace AimIK
{
    [DisallowMultipleComponent]
    public abstract class AimIKBehaviourBase : MonoBehaviour
    {
        #region Variables
            [SerializeField]
            private Transform target;

            [SerializeField]
            private bool smoothLookAt;

            [SerializeField]
            private float smoothTime;

            private Vector3 smoothTarget;
        #endregion

        #region SetterGetter
            public Transform Target
            {
                get { return target; }
                set { target = value; }
            }

            public bool SmoothLookAt
            {
                get { return smoothLookAt; }
                set { smoothLookAt = value; }
            }

            public float SmoothTime
            {
                get { return smoothTime; }
                set { smoothTime = value; }
            }

            protected Vector3 SmoothTarget
            {
                get { return smoothTarget; }
            }
        #endregion

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
