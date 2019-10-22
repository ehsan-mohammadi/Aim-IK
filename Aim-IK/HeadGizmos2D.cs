using UnityEngine;

namespace AimIK.Gizmos
{
    [RequireComponent(typeof(AimIKBehaviour2D))]
    public class HeadGizmos2D : MonoBehaviour
    {
        private AimIKBehaviour2D aimIKBehaviour;

        public bool showHeadLine = false;
        public Color headLineColor = Color.blue;

        /// <summary>
        /// The Awake function called first of all
        /// </summary>
        private void Awake()
        {
            // Set the aimIKBehaviour
            aimIKBehaviour = this.GetComponent<AimIKBehaviour2D>();
        }

        /// <summary>
        /// Draw Gizmos
        /// </summary>
        private void OnDrawGizmos()
        {
            if (aimIKBehaviour) // If aimIKBehaviour exists
            {
                if (showHeadLine)
                {
                    UnityEngine.Gizmos.color = headLineColor;
                    UnityEngine.Gizmos.DrawLine(aimIKBehaviour.head.part.position + new Vector3(aimIKBehaviour.head.positionOffset.x, aimIKBehaviour.head.positionOffset.y, 0), aimIKBehaviour.target.position);
                }
            }
        }
    }
}
