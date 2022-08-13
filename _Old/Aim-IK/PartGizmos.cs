using UnityEngine;

namespace AimIK.Gizmos
{
    using Properties;

    [RequireComponent(typeof(AimIKBehaviour))]
    public class PartGizmos : MonoBehaviour
    {
        #region Variables
            private AimIKBehaviour aimIKBehaviour;

            [SerializeField]
            private Transform part;

            private Transform exPart;

            private Part chestPart;

            [SerializeField]
            private bool showPartLine;

            [SerializeField]
            private Color partLineColor = Color.blue;
        #endregion

        #region SetterGetter
            public Transform Part
            {
                get { return part; }
                set { part = value; }
            }

            public bool ShowPartLine
            {
                get { return showPartLine; }
                set { showPartLine = value; }
            }

            public Color PartLineColor
            {
                get { return partLineColor; }
                set { partLineColor = value; }
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

        private void Update()
        {
            if (part != exPart)
            {
                bool found = false;

                // Find the part
                if (aimIKBehaviour.ChestParts.Length > 0)
                {
                    foreach (Part chestPart in aimIKBehaviour.ChestParts)
                    {
                        if (chestPart.part == part)
                        {
                            this.chestPart = chestPart;
                            exPart = part;
                            found = true;
                            break;
                        }
                    }

                    if(!found)
                    {
                        this.chestPart = null;
                        part = exPart = null;
                    }
                }
            }
        }

        /// <summary>
        /// Draw Gizmos
        /// </summary>
        private void OnDrawGizmos()
        {
            if (aimIKBehaviour) // If aimIKBehaviour exists
            {
                if (showPartLine)
                {
                    UnityEngine.Gizmos.color = partLineColor;
                    UnityEngine.Gizmos.DrawLine(chestPart.part.position + chestPart.positionOffset, aimIKBehaviour.Target.position);
                }
            }
        }
    }
}
