using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AimIK
{
    public class AimIKBehaviour : MonoBehaviour
    {
        public Transform head;
        public Transform target;
        
        /// <summary>
        /// LateUpdate called after Update and FixedUpdate functions each frames. This function is on top of any animation.
        /// </summary>
        public void LateUpdate()
        {
            head.LookAt(target);
        }
    }
}
