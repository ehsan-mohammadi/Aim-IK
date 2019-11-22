using UnityEngine;

namespace AimIK.Gizmos
{
    using Properties;

    [RequireComponent(typeof(AimIKBehaviour2D))]
    public class PartGizmos2D : MonoBehaviour
    {
        private AimIKBehaviour2D aimIKBehaviour;

        public Transform part;
        private Transform exPart;
        private Part2D chestPart;

        public bool showPartLine;
        public Color partLineColor = Color.blue;

        /// <summary>
        /// The Awake function called first of all
        /// </summary>
        private void Awake()
        {
            // Set the aimIKBehaviour
            aimIKBehaviour = this.GetComponent<AimIKBehaviour2D>();
        }

        private void Update()
        {
            if (part != exPart)
            {
                bool found = false;

                // Find the part
                if (aimIKBehaviour.chestParts.Length > 0)
                {
                    foreach (Part2D chestPart in aimIKBehaviour.chestParts)
                    {
                        if (chestPart.part == part)
                        {
                            this.chestPart = chestPart;
                            exPart = part;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
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
                    UnityEngine.Gizmos.DrawLine(chestPart.part.position + new Vector3(chestPart.positionOffset.x, chestPart.positionOffset.y, 0), aimIKBehaviour.target.position);
                }
            }
        }
    }
}
