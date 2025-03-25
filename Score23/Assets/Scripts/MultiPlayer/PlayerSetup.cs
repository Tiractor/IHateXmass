using Unity.Netcode;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    public Camera playerCamera; // Камера игрока

    void Start()
    {
        if (!IsOwner) // Только локальный игрок управляет своей камерой
        {
            if (playerCamera != null)
                playerCamera.gameObject.SetActive(false);
            return;
        }
    }
}
