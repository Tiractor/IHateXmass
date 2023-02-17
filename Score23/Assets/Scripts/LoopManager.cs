using System;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    [SerializeField] private Unit player;
    
    [SerializeField] private float _gameTime;
    private bool _isRunning;
    [SerializeField] private float _FirstBoss = 30;
    [SerializeField] private float _SecondBoss = 60;
    [SerializeField] private float _ThirdBoss = 90;
    [SerializeField] private int CurLevel = 1;


    public delegate void _Start1stBF();
    public static event _Start1stBF FirstBoss;
    public delegate void _Start2ndBF();
    public static event _Start2ndBF SecondBoss;
    public delegate void _Start3rdBF();
    public static event _Start3rdBF ThirdBoss;
    private void Awake()
    {
        RestartTimer();
        StartTimer();
    }

    private void FixedUpdate()
    {
        if(_isRunning) _gameTime += Time.fixedDeltaTime;
        switch (CurLevel)
        {
            case 1: if(_gameTime > _FirstBoss) FirstBoss(); StopTimer(); break;
            case 2: if (_gameTime > _SecondBoss) SecondBoss(); StopTimer(); break;
            case 3: if (_gameTime > _ThirdBoss) ThirdBoss(); StopTimer(); break;
        }
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
