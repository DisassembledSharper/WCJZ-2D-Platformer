using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers.ScenesManager;

public class FinalPoint : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScenesManager.Instance.LoadScene(nextScene);
        }
    }
}
