using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField]private float _maxTime = 20;
    private float _time = 0;
    private MilkSpawner _milkSpawner;
    private void Awake()
    {
        _milkSpawner = GetComponent<MilkSpawner>();
    }
    private void FixedUpdate()
    {
        IncreaseMaxEnemyFunction();
    }
    private void IncreaseMaxEnemyFunction()
    {
        if (_time >= _maxTime)
        {
            _milkSpawner.IncreaseMaxEnemy();
            _time = 0;
        }
        _time += Time.fixedDeltaTime;
    }
}
