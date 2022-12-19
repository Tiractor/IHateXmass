using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGingerMan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Gun>().DoubleAttack(2);
            Destroy(gameObject);
        }
    }

}
