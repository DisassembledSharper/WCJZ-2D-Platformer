using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers.ScenesManager;

namespace Points
{
    public class FinalPoint : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float launchForce;
        [SerializeField] private int nextScene;

        [Header("References")]
        [SerializeField] private Animator animator;
        private Rigidbody2D playerRig;
        [Header("Status")]
        [SerializeField] private bool wasPressed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (wasPressed) return;
                wasPressed = true;
                playerRig = collision.GetComponent<Rigidbody2D>();
                animator.SetTrigger("press");
                Invoke(nameof(LaunchPlayer), 0.3f);
                //Invoke(nameof(LoadNextScene), 2);
            }
        }

        private void LoadNextScene()
        {
            ScenesManager.Instance.LoadScene(nextScene);
        }

        private void LaunchPlayer()
        {
            playerRig.velocity = new Vector2(playerRig.velocity.x, 0);
            playerRig.AddForce(launchForce * Vector2.up, ForceMode2D.Impulse);
        }
    }
}