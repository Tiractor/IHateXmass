using UnityEngine;
using Unity.Netcode;

public class SimpleNetworkHUD : MonoBehaviour
{
    // ������� ������� ������ ��� ������ (��� �������� ����� ����������������)
    public float baseButtonWidth = 200f;
    public float baseButtonHeight = 40f;

    // ��������� � ������ (��������� ��� ����� ������ ���������)
    public float widthPercentage = 0.2f;
    public float heightPercentage = 0.05f;

    // ������� ������ ������
    public int baseFontSize = 20;

    // GUIStyle ��� ������������ ������ �� �������
    private GUIStyle buttonStyle;
    void Start()
    {
        NetworkManager.Singleton.ConnectionApprovalCallback += (request, response) =>
        {
            response.Approved = true;  // ������ ������ ����������
            response.CreatePlayerObject = true;
            response.PlayerPrefabHash = null;
            response.Position = Vector3.zero;
            response.Rotation = Quaternion.identity;
        };
    }

    private void OnGUI()
    {
        // ������������ ������� ������ � ������ � ����������� �� ���������� ������
        float buttonWidth = Screen.width * widthPercentage;
        float buttonHeight = Screen.height * heightPercentage;
        float spacing = buttonHeight * 0.2f; // ������������ ����� ��������
        if (buttonStyle == null)
        {
            buttonStyle = new GUIStyle(GUI.skin.button);
        }
        // ������������ �������������� ������ ������
        buttonStyle.fontSize = Mathf.RoundToInt(baseFontSize * (Screen.width / 1920f)); // 1920 - ������� ���������� ������

        GUILayout.BeginArea(new Rect(10, 10, buttonWidth + 20, Screen.height)); // ������� ������� ��� ������

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            // ������ ��� ������� �����
            if (GUILayout.Button("Start Host", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartHost();
                NetworkManager.Singleton.OnClientConnectedCallback += (clientId) =>
                {
                    Debug.Log($"Client {clientId} connected!");
                };

                NetworkManager.Singleton.OnClientDisconnectCallback += (clientId) =>
                {
                    Debug.Log($"Client {clientId} disconnected!");
                };
                NetworkManager.Singleton.OnClientDisconnectCallback += (clientId) =>
                {
                    Debug.Log($"[HOST] Client {clientId} disconnected!");
                };
            }

            GUILayout.Space(spacing); // ��������� ������������ ����� ��������

            // ������ ��� ������� �������
            if (GUILayout.Button("Start Server", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartServer();
            }

            GUILayout.Space(spacing); // ��������� ������������ ����� ��������

            // ������ ��� ������� �������
            if (GUILayout.Button("Start Client", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        else
        {
            // ������ ��� ��������� ������� ��� �������
            if (GUILayout.Button("Stop", buttonStyle, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
            {
                NetworkManager.Singleton.Shutdown();
            }
        }

        GUILayout.EndArea();
    }
}
