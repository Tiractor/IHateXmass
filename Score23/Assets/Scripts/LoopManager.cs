using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    private float _gameTime;
    private bool _isRunning;

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
