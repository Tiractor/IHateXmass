using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesPrefabs = new GameObject[4];
    [SerializeField] private float _delay = 1;
    [SerializeField] private bool _isSpawning = true;
    private float _timer = 0;
    private void FixedUpdate()
    {
        if (_isSpawning)
            SpawnEnemy();
    }
    private void SpawnEnemy()
    {
        if (_timer >= _delay)
        {
            Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)], transform.position, Quaternion.identity, transform);
            _timer = 0;
        }
        _timer += Time.fixedDeltaTime;
    }
    public void IsSpawning(bool isspawning)
    {
        _isSpawning = isspawning;
    }
}
