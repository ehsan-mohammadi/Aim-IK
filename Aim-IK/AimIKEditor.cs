using UnityEditor;

namespace AimIK
{
    [CustomEditor(typeof(AimIKGizmos))]
    public class AimIKEditor : Editor
    {
        /// <summary>
        /// Do something when you are in inspector
        /// </summary>
        public override void OnInspectorGUI()
        {
            // For other non-HideInInspector fields
            DrawDefaultInspector();

            AimIKGizmos aimIKGizmos = (AimIKGizmos)target;

            if(aimIKGizmos.showHeadLine)
            {
                // Show the Head-Line-Color box
                aimIKGizmos.headLineColor = EditorGUILayout.ColorField("Head Line Color", aimIKGizmos.headLineColor);
            }
        }
    }
}
