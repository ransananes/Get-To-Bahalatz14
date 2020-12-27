using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }

    void SignIn()
    {
        if (Social.localUser.authenticated == false)
            Social.localUser.Authenticate(success => { });
    }

    #region Achievements
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public static void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { });
    }

    public static void ShowLeaderboardsUI()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_kilometers);
        else
            Social.localUser.Authenticate((bool success) =>
            {
                PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_kilometers);
            }); 
    #endregion /Leaderboards
        }
    
}