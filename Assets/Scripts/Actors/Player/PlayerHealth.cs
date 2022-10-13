using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actors.BaseClasses.Health;

namespace Actors.Player
{
    public class PlayerHealth : HealthSystem
    {
        [Header("References")]
        [SerializeField] private Player player;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            currentHealth = startHealth;
            canTakeDamage = true;
        }

        protected override void OnTakeDamage()
        {
            StartCoroutine(Recovery(0.05f));
        }

        private IEnumerator Recovery(float delay)
        {
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
    }
}