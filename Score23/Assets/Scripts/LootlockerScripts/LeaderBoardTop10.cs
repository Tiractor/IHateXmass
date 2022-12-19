using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class LeaderBoardTop10 : MonoBehaviour
{
    private readonly string _leaderboardKey = "time";
    private readonly int _count = 10;

    private TextMeshProUGUI _scoreboardText;

    private void Start()
    {
        _scoreboardText = gameObject.GetComponent<TextMeshProUGUI>();
        LootLockerSDKManager.GetScoreList(_leaderboardKey, _count, (response =>
        {
            if (!response.success) return;
            string leaderboardText = "<b>TOP 10 Santas:</b>\n";
            foreach (var currentEntry in response.items)
            {
                leaderboardText += currentEntry.rank + ".";
                leaderboardText += currentEntry.player.name;
                leaderboardText += " - ";
                leaderboardText += currentEntry.score + " sec";
                leaderboardText += "\n";
            }
            _scoreboardText.text = leaderboardText;
        }));
    }
}
