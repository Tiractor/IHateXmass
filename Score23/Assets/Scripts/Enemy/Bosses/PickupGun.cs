using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    public GameObject[] ShowObjects;
    public GameObject[] HideObjects;
    [SerializeField] GameObject NewGun;
    public bool Destroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject Temp = other.GetComponent<MainPlayerController>().CurrentGun;

            foreach (GameObject show in ShowObjects)
            {
                show.SetActive(true);
            }
            foreach (GameObject show in HideObjects)
            {
                show.SetActive(false);
            }

            other.GetComponent<Unit>().Attack = NewGun.GetComponent<AttackType>();
            Temp.active = false;
            Temp = NewGun;
            Temp.active = true;

            if (Destroy)
                Destroy(gameObject);
        }
    }
}
