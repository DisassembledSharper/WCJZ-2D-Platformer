using System.Collections;
using UnityEngine;
using Actors.BaseClasses.Health;
using Managers.ScreenUIManager;

namespace Actors.Player
{
    public class PlayerHealth : HealthSystem
    {
        [Header("References")]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerJump playerJump;

        private void Start()
        {
            currentHealth = startHealth;
            canTakeDamage = true;
            UpdateHealthText();
        }

        protected override void OnTakeDamage()
        {
            UpdateHealthText();
            StartCoroutine(Recovery(0.05f));
        }

        protected override void OnDie()
        {
            playerMovement.enabled = false;
            playerJump.enabled = false;
            ScreenUIManager.Instance.ShowGameOver();
        }

        private IEnumerator Recovery(float delay)
        {
            if (isDead) yield break;
            Color color = spriteRenderer.color;
            canTakeDamage = false;
            for (int i = 0; i < 10; i++)
            {
                color.a = 0;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(delay);
                color.a = 1;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(delay);
            }
            canTakeDamage = true;
        }

        private void UpdateHealthText()
        {
            ScreenUIManager.Instance.UpdatePlayerHealthText(currentHealth.ToString());
        }
    }
}