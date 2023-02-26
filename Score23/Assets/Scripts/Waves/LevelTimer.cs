using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeStart;
    public GameObject[] ShowObjects;
    public GameObject[] HideObjects;
    private void Start()
    {
        timerText.text = timeStart.ToString();
    }
    private void Update()
    {
        if (timeStart <= 0)
        {
            foreach (GameObject show in ShowObjects)
            {
                show.SetActive(true);
            }
            foreach (GameObject show in HideObjects)
            {
                show.SetActive(false);
            }
        }
        timeStart -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Round(timeStart).ToString();
    }
}
