using System;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [SerializeField] private Unit player;
    
    [SerializeField] private float _gameTime;
    private bool _isRunning;

    private void Start()
    {
        RestartTimer();
        StartTimer();
    }

    private void FixedUpdate()
    {
        if(_isRunning) _gameTime += Time.fixedDeltaTime;
    }

    public void RestartTimer()
    {
        _gameTime = 0;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void StartTimer()
    {
        _isRunning = true;
    }

    public float ReturnTime()
    {
        return _gameTime;
    }
}
