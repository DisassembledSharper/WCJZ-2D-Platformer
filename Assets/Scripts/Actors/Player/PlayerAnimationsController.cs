using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Animator animator;

        private void Update()
        {
            if (player.IsWalking && !player.IsJumping) SetAnimationState(1);
            else if (!player.IsWalking && !player.IsJumping) SetAnimationState(0);
            else if (player.IsJumping) SetAnimationState(2);
        }

        public void SetAnimationState(int state)
        {
            animator.SetInteger("state", state);
        }
    }
}