using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Unit player;
    [SerializeField] private Slider hpSlider;
    private float _maxHitPoints;

    private void OnEnable()
    {
        if(player != null) _maxHitPoints = player.ReturnHP();
    }

    private void Update()
    {
        if (player != null) hpSlider.value = player.ReturnHP() / _maxHitPoints;
    }
}
