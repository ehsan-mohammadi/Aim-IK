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
            private SerializedProperty head;
            private SerializedProperty spines;
        #endregion

        private void OnEnable ()
        {
            aimIK = (AimIKBehaviourBase)target;
            
            targetPoint = serializedObject.FindProperty("target");
            isSmoothLookAt = serializedObject.FindProperty("isSmoothLookAt");
            smoothTime = serializedObject.FindProperty("smoothTime");
            head = serializedObject.FindProperty("head");
            spines = serializedObject.FindProperty("spines");
        }

        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(targetPoint);

            EditorGUILayout.PropertyField(head);
            EditorGUILayout.PropertyField(spines, true);

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