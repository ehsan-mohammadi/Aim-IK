#if UNITY_EDITOR

using UnityEditor;

namespace AimIK.Editor
{
    using Behaviour;

    [CustomEditor(typeof(AimIKBehaviourBase), true)]
    public class AimIKBehaviourEditor : UnityEditor.Editor
    {
        private AimIKBehaviourBase aimIK;
        private bool smoothLookAtGroup = false;

        #region SerializedProperties
            private SerializedProperty targetPoint;
            private SerializedProperty isSmoothLookAt;
            private SerializedProperty smoothTime;
        #endregion

        private void OnEnable ()
        {
            aimIK = (AimIKBehaviourBase)target;
            
            targetPoint = serializedObject.FindProperty("target");
            isSmoothLookAt = serializedObject.FindProperty("isSmoothLookAt");
            smoothTime = serializedObject.FindProperty("smoothTime");
        }

        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(targetPoint);

            smoothLookAtGroup = EditorGUILayout
                .BeginFoldoutHeaderGroup(smoothLookAtGroup, "Smooth Look At");
            if (smoothLookAtGroup)
            {
                EditorGUILayout.PropertyField(isSmoothLookAt);
                if (aimIK.IsSmoothLookAt)
                    EditorGUILayout.PropertyField(smoothTime);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif