using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public int maxEnemy = 1;

    public float timeSpawn = 2f;
    private float timer;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && itemPrefab.Length > 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                int random = Random.Range(0, itemPrefab.Length);
                Instantiate(itemPrefab[random], transform.position, Quaternion.identity, transform);
            }
        }
    }

}
