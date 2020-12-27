using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI txt_highscore;
    // Start is called before the first frame update
    void Start()
    {

       int highscore = PlayerPrefs.GetInt("highscore");
        txt_highscore.text = ""+ highscore;
        AssetBundle.UnloadAllAssetBundles(false);
        bool success = Caching.ClearCache();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }
    private void OnApplicationQuit()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        bool success = Caching.ClearCache();
    }
}
