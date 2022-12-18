using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCrystall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FirstPersonMovement_Mod>().ChangeSpeed();
            Destroy(gameObject);
        }
    }
    
}
