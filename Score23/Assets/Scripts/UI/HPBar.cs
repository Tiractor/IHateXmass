using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Unit player;
    [SerializeField] private Slider hpSlider;

    private void Update()
    {
        hpSlider.value = player.ReturnHP() / 100;
    }
}
