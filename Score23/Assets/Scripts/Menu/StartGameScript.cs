using UnityEngine.SceneManagement;
using UnityEngine;

namespace MenuSpace
{
    public class StartGameScript : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("MapBuilding");
        }
        public void InitMultiplayer()
        {
            gameObject.AddComponent<SimpleNetworkHUD>();
        }
    }
}
