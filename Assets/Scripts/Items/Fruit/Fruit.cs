using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers.FruitsManager;

namespace Items.Fruit
{
    public class Fruit : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private string fruitName;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                FruitsManager.Instance.AddFruitCount(fruitName, 1);
                Destroy(gameObject);
            }
        }
    }
}