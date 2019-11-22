using UnityEngine;

namespace AimIK.Gizmos
{
    using Properties;

    [RequireComponent(typeof(AimIKBehaviour))]
    public class PartGizmos : MonoBehaviour
    {
        private AimIKBehaviour aimIKBehaviour;

        public Transform part;
        private Transform exPart;
        private Part chestPart;

        public bool showPartLine;
        public Color partLineColor = Color.blue;

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
                if (aimIKBehaviour.chestParts.Length > 0)
                {
                    foreach (Part chestPart in aimIKBehaviour.chestParts)
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
                    UnityEngine.Gizmos.DrawLine(chestPart.part.position + chestPart.positionOffset, aimIKBehaviour.target.position);
                }
            }
        }
    }
}
