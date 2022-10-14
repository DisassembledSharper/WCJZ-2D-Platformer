using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerJump playerJump;
        [SerializeField] private Animator animator;

        private void Update()
        {
            if (playerMovement.IsWalking && !playerJump.IsJumping) SetAnimationState(1);
            else if (!playerMovement.IsWalking && !playerJump.IsJumping) SetAnimationState(0);
            else if (playerJump.IsJumping) SetAnimationState(2);
        }

        public void SetAnimationState(int state)
        {
            animator.SetInteger("state", state);
        }
    }
}