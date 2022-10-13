using UnityEngine;

namespace Actors.BaseClasses.Health
{
    public class HealthSystem : MonoBehaviour
    {
        [Header("Config")]
        protected int startHealth = 3;

        [Header("Status")]
        [SerializeField] protected int currentHealth;
        [SerializeField] protected bool canTakeDamage = true;
        
        public void TakeDamage(int damageValue)
        {
            if (!canTakeDamage) return;
            currentHealth -= damageValue;
            OnTakeDamage();
        }

        protected virtual void OnTakeDamage() { }
    }
}