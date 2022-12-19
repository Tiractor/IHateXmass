using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderBoardTop10 : MonoBehaviour
{
    private string _leaderboardKey = "time";
    private int _count = 10;

    private TextMeshProUGUI _scoreboardText;

    private void Start()
    {
        _scoreboardText = gameObject.GetComponent<TextMeshProUGUI>();
        LootLockerSDKManager.GetScoreList(_leaderboardKey, _count, (response =>
        {
            if (response.success)
            {
                string leaderboardText = "<b>TOP 10 Santas:</b>\n";
                for (int i = 0; i < response.items.Length; i++)
                {
                    LootLockerLeaderboardMember currentEntry = response.items[i];
                    leaderboardText += currentEntry.rank + ".";
                    leaderboardText += currentEntry.metadata;
                    leaderboardText += " - ";
                    leaderboardText += currentEntry.score;
                    leaderboardText += "\n";
                }
                _scoreboardText.text = leaderboardText;
            }
        }));
    }
}
