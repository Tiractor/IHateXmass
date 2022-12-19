using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class SubmitScore : MonoBehaviour
{
    private TextMeshProUGUI _yourScore;
    private void Start()
    {
        _yourScore = GetComponent<TextMeshProUGUI>();
        _yourScore.text = "Your score: " + PlayerPrefs.GetInt("Time") + " seconds";
    }

    public void SubmitScoreButton()
    {
        LootLockerSDKManager.SubmitScore(PlayerPrefs.GetInt("PlayerID").ToString(), PlayerPrefs.GetInt("Time"), "time",
            response =>
            {
                return;
            });
    }
}
