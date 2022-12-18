using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
        if (timer <= 0)
        {
            timer = timeSpawn;
            if (transform.childCount < maxEnemy)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            }
        }
    }
}
