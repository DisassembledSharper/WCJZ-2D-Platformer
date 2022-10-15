using UnityEngine;

namespace Actors.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float walkSpeed;

        [Header("References")]
        [SerializeField] private Rigidbody2D rig;

        [Header("Status")]
        [SerializeField] private float horizontalInput;
        [SerializeField] private bool isWalking;

        public bool IsWalking { get => isWalking; private set => isWalking = value; }
        public float HorizontalInput { get => horizontalInput; private set => horizontalInput = value; }

        private void Update()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            rig.velocity = new Vector2(horizontalInput * walkSpeed * Time.fixedDeltaTime, rig.velocity.y);

            if (horizontalInput != 0) IsWalking = true;
            else IsWalking = false;

            if (horizontalInput > 0) transform.eulerAngles = Vector2.zero;
            else if (horizontalInput < 0) transform.eulerAngles = new Vector2(0, 180);
        }
    }
}