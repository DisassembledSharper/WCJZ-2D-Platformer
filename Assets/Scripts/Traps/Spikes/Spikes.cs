using UnityEngine;
using Actors.Player.Health;

namespace Traps
{
    public class Spikes : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(1);
            }
        }
    }
}
