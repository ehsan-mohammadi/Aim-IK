using UnityEngine;

namespace Sample
{
    public class UpDownMovement : MonoBehaviour
    {
        [SerializeField] private float movementFactor = 0.5f;
        private Vector3 offset;
        private float movement;

        private void Awake ()
        {
            offset = this.transform.position;
        }

        private void Update ()
        {
            movement = Mathf.Sin(Time.time) * movementFactor;
        }

        private void FixedUpdate ()
        {
            this.transform.position = offset + new Vector3(0, movement, 0);
        }
    }
}