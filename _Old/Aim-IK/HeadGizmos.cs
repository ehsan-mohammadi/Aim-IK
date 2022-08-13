using UnityEngine;

namespace AimIK.Gizmos
{
    [RequireComponent(typeof(AimIKBehaviour))]
    public class HeadGizmos : MonoBehaviour
    {
        #region Variables
            private AimIKBehaviour aimIKBehaviour;

            [SerializeField]
            private bool showHeadLine = false;

            [SerializeField]
            private Color headLineColor = Color.blue;
        #endregion

        #region SetterGetter
            public bool ShowHeadLine
            {
                get { return showHeadLine; }
                set { showHeadLine = value; }
            }

            public Color HeadLineColor
            {
                get { return headLineColor; }
                set { headLineColor = value; }
            }
        #endregion

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
                    UnityEngine.Gizmos.DrawLine(aimIKBehaviour.Head.part.position + aimIKBehaviour.Head.positionOffset, aimIKBehaviour.Target.position);
                }
            }
        }
    }
}
