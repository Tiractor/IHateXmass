using LootLocker.Requests;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;

    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");
                return;
            }
            PlayerPrefs.SetInt("PlayerID",response.player_id);
            PlayerPrefs.Save();
            Debug.Log("successfully started LootLocker session");
        });
    }

    public void SetPlayerName(string sceneName)
    {
        string newPlayerName = playerNameInput.text;
        if(LootLockerSDKManager.CheckInitialized()) LootLockerSDKManager.SetPlayerName(newPlayerName, response =>
        {
            if(response.success) SceneManager.LoadScene(sceneName);
        });
    }
}
