using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time = 0;
    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
    }
    public float GetTime()
    {
        return _time;
    }
}
