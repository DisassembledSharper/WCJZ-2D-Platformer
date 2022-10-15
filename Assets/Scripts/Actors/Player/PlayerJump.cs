using UnityEngine;
using Actors.Other;

namespace Actors.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float jumpForce;

        [Header("References")]
        [SerializeField] private Rigidbody2D rig;
        [SerializeField] private GroundDetector groundDetector;
        [SerializeField] private PlayerAnimationsController animationsController;

        [Header("Status")]
        [SerializeField] private bool isJumping;
        [SerializeField] private bool jumpRequest;
        [SerializeField] private bool doubleJumpRequest;
        [SerializeField] private bool canDoubleJump;
        [SerializeField] private bool isDoubleJumping;
        [SerializeField] private bool isFalling;
        [SerializeField] private bool isOnGround;

        public bool IsJumping { get => isJumping; private set => isJumping = value; }
        public bool IsOnGround { get => isOnGround; private set => isOnGround = value; }
        public bool IsFalling { get => isFalling; private set => isFalling = value; }
        public bool IsDoubleJumping { get => isDoubleJumping; private set => isDoubleJumping = value; }

        private void Update()
        {
            if (Input.GetButtonDown("Jump") && isOnGround) jumpRequest = true;
            if (Input.GetButtonDown("Jump") && canDoubleJump) doubleJumpRequest = true;
        }

        private void FixedUpdate()
        {
            isOnGround = groundDetector.IsOnGround;
            if (jumpRequest)
            {
                Jump();
                jumpRequest = false;
                IsJumping = true;
                canDoubleJump = true;
                animationsController.SetAnimationTrigger("jump");
            }
            else if (doubleJumpRequest)
            {
                Jump();
                doubleJumpRequest = false;
                canDoubleJump = false;
                isDoubleJumping = true;
                animationsController.SetAnimationTrigger("doubleJump");
            }

            if (rig.velocity.y <= 0 && isJumping) isFalling = true;
            else isFalling = false;

            if (isOnGround && rig.velocity.y <= 1.5f)
            {
                isJumping = false;
                canDoubleJump = false;
                isDoubleJumping = false;
            }
        }

        private void Jump()
        {
            rig.velocity = new Vector3(rig.velocity.x, 0);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}