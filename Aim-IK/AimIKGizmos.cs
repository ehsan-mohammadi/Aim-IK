using UnityEngine;
using AimIK;

namespace AimIK
{
    [RequireComponent(typeof(AimIKBehaviour))]
    public class AimIKGizmos : MonoBehaviour
    {
        AimIKBehaviour aimIKBehaviour;
        
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
        public void OnDrawGizmos()
        {
            if(aimIKBehaviour) // If aimIKBehaviour exists
            {
                if(showHeadLine)
                {
                    Gizmos.color = headLineColor;
                    Gizmos.DrawLine(aimIKBehaviour.head.position + aimIKBehaviour.eyesOffset, aimIKBehaviour.target.position);
                }
            }
        }
    }
}
