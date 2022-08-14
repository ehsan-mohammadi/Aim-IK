using UnityEngine;
using AimIK.Behaviour;

namespace Sample
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Transform target1;
        [SerializeField] private Transform target2;
        private AimIKBehaviour3D aimIK;

        private void Awake ()
        {
            aimIK = this.GetComponent<AimIKBehaviour3D>();
        }

        private void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                aimIK.Target = (aimIK.Target == target1) ? target2 : target1;
        }
    }
}