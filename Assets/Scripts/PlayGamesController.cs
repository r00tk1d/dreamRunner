using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AuthenticateUser();

    }

    private void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Logged In to Google Play Services");

                GetComponent<Image>().color = Color.green;

            }

            else
            {
                Debug.LogError("Unable to sign in to Google Play Services");
                GetComponent<Image>().color = Color.red;
            }
        });

    }

    public static void PostToLeaderBoard(long newScore)
    {
        Social.ReportScore(newScore, GPGSIds.leaderboard_highscore, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Posted New score to Leaderboard");
            }
            else
            {
                Debug.LogError("posting new score to leaderboard failed");
            }
        });
    }

    public void ShowLeaderBoardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_highscore);
    }

}
