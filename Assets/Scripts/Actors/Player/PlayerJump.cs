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

        [Header("Status")]
        [SerializeField] private bool isJumping;
        [SerializeField] private bool isOnGround;

        public bool IsJumping { get => isJumping; private set => isJumping = value; }
        public bool IsOnGround { get => isOnGround; private set => isOnGround = value; }

        private void Update()
        {
            isOnGround = groundDetector.IsOnGround;

            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                IsJumping = true;
            }

            if (isOnGround && rig.velocity.y <= 0) isJumping = false;
        }
    }
}