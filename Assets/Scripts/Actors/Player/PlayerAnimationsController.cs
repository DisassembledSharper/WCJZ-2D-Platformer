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
            animator.SetBool("isJumping", playerJump.IsJumping);
            if (playerMovement.IsWalking && !playerJump.IsJumping) SetAnimationState(1);
            else if (!playerMovement.IsWalking && !playerJump.IsJumping || !playerJump.IsFalling) SetAnimationState(0);
            else if (playerJump.IsJumping && playerJump.IsFalling) SetAnimationState(2);
        }

        public void SetAnimationState(int state)
        {
            animator.SetInteger("state", state);
        }

        public void SetAnimationTrigger(string triggerName)
        {
            animator.SetTrigger(triggerName);
        }
    }
}