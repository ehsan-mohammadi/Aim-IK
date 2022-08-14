using UnityEngine;

namespace AimIK.Entity
{
    public abstract class Unit : MonoBehaviour
    {
        protected abstract void Initialize ();

        private void Awake ()
        {
            Initialize();
        }
    }
}