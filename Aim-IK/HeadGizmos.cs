using UnityEngine;
using AimIK;

namespace AimIK.Gizmos
{
    [RequireComponent(typeof(AimIKBehaviour))]
    public class HeadGizmos : MonoBehaviour
    {
        private AimIKBehaviour aimIKBehaviour;
        
        public bool showHeadLine = false;
        public Color headLineColor = Color.blue;

        /// <summary>
        /// The Awake function called first of all
        /// </summary>
        private void Awake()
        {
            // Set the aimIKBehaviour
            aimIKBehaviour = this.GetComponent<AimIKBehaviour>();
        }

        /// <summary>
        /// Draw Gizmos
        /// </summary>
        private void OnDrawGizmos()
        {
            if(aimIKBehaviour) // If aimIKBehaviour exists
            {
                if(showHeadLine)
                {
                    UnityEngine.Gizmos.color = headLineColor;
                    UnityEngine.Gizmos.DrawLine(aimIKBehaviour.head.position + aimIKBehaviour.eyesOffset, aimIKBehaviour.target.position);
                }
            }
        }
    }
}
