using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField] GameObject Door, Explosion;
    [SerializeField] GameObject NewGun, HUDPrev, HUDNew;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject Temp = other.GetComponent<MainPlayerController>().CurrentGun;

            Explosion.SetActive(true);
            Door.SetActive(false);

            HUDPrev.SetActive(false);
            HUDNew.SetActive(true);

            other.GetComponent<Unit>().Attack = NewGun.GetComponent<AttackType>();
            Temp.active = false;
            Temp = NewGun;
            Temp.active = true;


            Destroy(gameObject);
        }
    }
}
