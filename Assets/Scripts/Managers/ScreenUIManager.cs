using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

namespace Managers.ScreenUIManager
{
    public class ScreenUIManager : MonoBehaviour
    {
        [Header("References")]
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI appleText;
        [SerializeField] private TextMeshProUGUI playerHealthText;
        [Header("GameObjects")]
        [SerializeField] private GameObject gameOverObject;

        public static ScreenUIManager Instance { get; private set; }

        private void Awake() => Instance = this;

        public void UpdateAppleText(string text)
        {
            appleText.text = text;
        }

        public void UpdatePlayerHealthText(string text)
        {
            playerHealthText.text = text;
        }

        public void ShowGameOver()
        {
            gameOverObject.SetActive(true);
        }
    }
}