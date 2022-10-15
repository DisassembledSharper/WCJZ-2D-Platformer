using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.ScenesManager
{
    public class ScenesManager : MonoBehaviour
    {
        public static ScenesManager Instance { get; private set; }

        private void Awake() => Instance = this;

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}