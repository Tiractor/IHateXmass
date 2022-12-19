using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class MyRank : MonoBehaviour
{
    private readonly string _leaderboardKey = "time";

    private TextMeshProUGUI _myRank;

    private void Start()
    {
        _myRank = gameObject.GetComponent<TextMeshProUGUI>();
        
        LootLockerSDKManager.GetMemberRank(_leaderboardKey, PlayerPrefs.GetInt("PlayerID"), (response) =>
        {
            if (response.success)
            {
                if (response.rank == 0) 
                    _myRank.text = "No current rank";
                else 
                    _myRank.text = "Your rank is:" + response.rank + " - " + response.score + " sec";
            }
        });
    }
}
