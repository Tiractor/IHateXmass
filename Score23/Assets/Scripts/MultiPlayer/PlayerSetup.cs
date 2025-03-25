using Unity.Netcode;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    public Camera playerCamera; // ������ ������

    void Start()
    {
        if (!IsOwner) // ������ ��������� ����� ��������� ����� �������
        {
            if (playerCamera != null)
                playerCamera.gameObject.SetActive(false);
            return;
        }
    }
}
