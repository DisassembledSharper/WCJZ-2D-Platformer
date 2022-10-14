using UnityEngine;
namespace Managers.FruitsManager
{
    public class FruitsManager : MonoBehaviour
    {
        [Header("Status")]
        [SerializeField] private int currentApples;

        public static FruitsManager Instance { get; private set; }
        public int CurrentApples { get => currentApples; private set => currentApples = value; }

        private void Awake() => Instance = this;

        public void AddFruitCount(string fruitName, int value)
        {
            fruitName = fruitName.ToLower();
            switch(fruitName)
            {
                case "apple":
                    currentApples += value;
                    ScreenUIManager.ScreenUIManager.Instance.UpdateAppleText(currentApples.ToString());
                    break;
                default:
                    Debug.LogError("Invalid fruit name.");
                    break;
            }
        }
    }
}