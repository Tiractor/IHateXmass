using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public GameObject Wall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Wall.SetActive(true);
            Destroy(gameObject);
        }
    }
}
