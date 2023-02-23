using System;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Unit player;
    [SerializeField] private Slider hpSlider;
    private float _maxHitPoints;

    private void OnEnable()
    {
        _maxHitPoints = player.ReturnHP();
    }

    private void Update()
    {
        hpSlider.value = player.ReturnHP() / _maxHitPoints;
    }
}
