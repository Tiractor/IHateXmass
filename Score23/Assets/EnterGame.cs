using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Spawner;
    public GameObject NextLevel;
    public GameObject PreviousLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Wall.SetActive(true);
            Spawner.SetActive(true);
            NextLevel.SetActive(true);
            PreviousLevel.SetActive(false);
            Destroy(gameObject);
        }
    }
}
