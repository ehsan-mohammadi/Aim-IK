using UnityEngine;

namespace Sample
{
    public class UpDownMovement : MonoBehaviour
    {
        [SerializeField] private bool inverse = false;
        private Vector3 offset;
        private float movement;

        private void Awake ()
        {
            offset = this.transform.position;
        }

        private void Update ()
        {
            movement = (inverse ? 1 : -1) * Mathf.Sin(Time.time) * 0.5f;
        }

        private void FixedUpdate ()
        {
            this.transform.position = offset + new Vector3(0, movement, 0);
        }
    }
}