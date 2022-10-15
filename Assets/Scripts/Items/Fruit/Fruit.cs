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

        [Header("References")]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject collectedObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                FruitsManager.Instance.AddFruitCount(fruitName, 1);
                spriteRenderer.enabled = false;
                collectedObject.SetActive(true);
                Destroy(gameObject, 0.4f);
            }
        }
    }
}