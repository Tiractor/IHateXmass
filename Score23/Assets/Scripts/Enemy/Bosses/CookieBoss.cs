using UnityEngine;

public class CookieBoss : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyToSpawn;
    [SerializeField] private GameObject enemiesHolder;
    [SerializeField] private GameObject DefeatEffect;
    [SerializeField] private GameObject Weapon;
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
        if (_timer > spawnerTime)
        {
            if(enemiesHolder.transform.childCount <= 1)
                SpawnEnemies();
            _timer = 0;
        }
        CheckChildCount();    
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawnCount; i++)
        {
            int random = Random.Range(0, enemyToSpawn.Length);
            Instantiate(enemyToSpawn[random], transform.position, Quaternion.identity, enemiesHolder.transform);
        }
    }

    private void CheckChildCount()
    {
        _bossUnit.isImmortal = enemiesHolder.transform.childCount > 0;
    }

    private void OnDestroy()
    {
        Instantiate(DefeatEffect, transform.position, Quaternion.identity, enemiesHolder.transform);
        Weapon.SetActive(true);
    }
}
