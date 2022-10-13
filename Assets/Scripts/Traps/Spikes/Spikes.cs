using Actors.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class Spikes : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().Hit();
            }
        }
    }
}
