using Actors.Player.Jump;
using Actors.Player.Movement;
using Managers.ScenesManager;
using UnityEngine;

namespace Points
{
    public class FinalPoint : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float launchForce;
        [SerializeField] private int nextScene;

        [Header("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private ParticleSystem confetti;
        [SerializeField] private SpriteRenderer finalSpriteRenderer;
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
                collision.GetComponent<PlayerJump>().FreezeInput = true;
                collision.GetComponent<PlayerMovement>().FreezeInput = true;

                animator.SetTrigger("press");

                Invoke(nameof(LaunchPlayer), 0.3f);
                Invoke(nameof(LoadNextScene), 3);
            }
        }

        private void LoadNextScene()
        {
            ScenesManager.Instance.LoadScene(nextScene);
        }

        private void LaunchPlayer()
        {
            confetti.Play();
            Invoke(nameof(ChangeLayer), 1);
            playerRig.velocity = new Vector2(playerRig.velocity.x, 0);
            playerRig.AddForce(launchForce * Vector2.up, ForceMode2D.Impulse);
        }
        private void ChangeLayer()
        {
            finalSpriteRenderer.sortingOrder -= 2;
        }
    }
}