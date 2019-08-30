using UnityEngine;

namespace AimIK
{
    public class AimIKBehaviour : MonoBehaviour
    {
        public Transform head;
        public Transform target;

        public Vector3 eyesOffset;
        
        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        private void LateUpdate()
        {
            head.LookAt(target.position - eyesOffset);
        }
    }
}
