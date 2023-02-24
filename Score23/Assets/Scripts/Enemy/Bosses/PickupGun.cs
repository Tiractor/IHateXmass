using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField] GameObject Door, Explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Explosion.SetActive(true);
            Door.SetActive(false);
            Destroy(gameObject);
        }
    }
}
