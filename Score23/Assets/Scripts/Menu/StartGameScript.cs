using UnityEngine.SceneManagement;
using UnityEngine;

namespace MenuSpace
{
    public class StartGameScript : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
