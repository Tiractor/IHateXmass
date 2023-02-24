using System;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public GameObject[] ShowObjects;
    public GameObject[] HideObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject show in ShowObjects)
            {
                show.SetActive(true);
            }
            foreach (GameObject show in HideObjects)
            {
                show.SetActive(false);
            }
        }
    }
}
