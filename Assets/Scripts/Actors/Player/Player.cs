using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float jumpForce;

        [Header("References")]
        [SerializeField] private Rigidbody2D rig;

        [Header("Status")]
        [SerializeField] private Vector2 direction = new();
        [SerializeField] private bool isOnGround;
        [SerializeField] private bool isWalking;
        [SerializeField] private bool isJumping;

        public bool IsWalking { get => isWalking; private set => isWalking = value; }
        public bool IsJumping { get => isJumping; private set => isJumping = value; }

        private void Update()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            if (direction.x != 0) isWalking = true;
            else isWalking = false;

            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                isJumping = true;
                isOnGround = false;
                Jump();
            }
            PlayerRotation();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            rig.velocity = new Vector2(direction.x * walkSpeed, rig.velocity.y);
        }

        private void Jump()
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        private void PlayerRotation()
        {
            if (direction.x > 0) transform.eulerAngles = Vector2.zero;
            else if (direction.x < 0) transform.eulerAngles = new Vector2(0, 180);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                isOnGround = true;
                IsJumping = false;
            }
        }
    }
}