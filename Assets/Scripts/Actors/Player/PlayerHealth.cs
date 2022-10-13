using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int currentHealth;

        private bool isRecovering;

        private void Start()
        {
            currentHealth = player.StartHealth;
        }

        public void Hit()
        {
            if (isRecovering) return;
            currentHealth--;
            StartCoroutine(Flick(0.05f));
        }

        private IEnumerator Flick(float delay)
        {
            Color color = spriteRenderer.color;
            isRecovering = true;
            for (int i = 0; i < 10; i++)
            {
                color.a = 0;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(delay);
                color.a = 1;
                spriteRenderer.color = color;
                yield return new WaitForSeconds(delay);
            }
            isRecovering = false;
        }
    }
}