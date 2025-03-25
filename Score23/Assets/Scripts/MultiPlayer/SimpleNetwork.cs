using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class SimpleNetwork : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        if (NetworkManager.Singleton == null)
        {
            Debug.LogError("NetworkManager not found in the scene!");
            return;
        }

        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
    }

    private void StartHost()
    {
        if (NetworkManager.Singleton.StartHost())
        {
            Debug.Log("Host started.");
        }
        else
        {
            Debug.LogError("Failed to start host.");
        }
    }
    private void StartClient()
    {
        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Client started.");
        }
        else
        {
            Debug.LogError("Failed to start client.");
        }
    }
}
