using UnityEngine.SceneManagement;
using UnityEngine;

namespace MenuSpace
{
    public class StartGameScript : MonoBehaviour
    {
        [SerializeField] private int _loadSceneIndex = 1;
        public void StartGame()
        {
            SceneManager.LoadScene(_loadSceneIndex);
        }
    }
}
