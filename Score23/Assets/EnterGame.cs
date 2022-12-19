using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Wall.SetActive(true);
            Spawner.SetActive(true);
            Destroy(gameObject);
        }
    }
}
