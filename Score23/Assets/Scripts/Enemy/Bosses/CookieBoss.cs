using UnityEngine;

public class CookieBoss : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn, enemiesHolder;
    [SerializeField] private float spawnerTime;
    [SerializeField] private int enemiesToSpawnCount;
    private float _timer;
    
    
    private Unit _bossUnit;

    private void OnEnable()
    {
        _bossUnit = GetComponent<Unit>();
        SpawnEnemies();
    }

    private void Update()
    {
        _timer += Time.fixedDeltaTime;
        Debug.Log(_timer);
        if (_timer > spawnerTime && enemiesHolder.transform.childCount <= 1)
        {
            SpawnEnemies();
            _timer = 0;
        }
        CheckChildCount();    
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawnCount; i++)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity, enemiesHolder.transform);
        }
    }

    private void CheckChildCount()
    {
        _bossUnit.isImmortal = enemiesHolder.transform.childCount > 0;
    }
}
