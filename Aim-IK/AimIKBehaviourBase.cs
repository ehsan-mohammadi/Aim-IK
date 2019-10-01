using UnityEngine;

namespace AimIK
{
    [DisallowMultipleComponent]
    public abstract class AimIKBehaviourBase : MonoBehaviour
    {
        public Transform head;
        public Transform target;
    }
}
