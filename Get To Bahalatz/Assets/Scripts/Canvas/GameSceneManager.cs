using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameSceneManager: MonoBehaviour
{
	[Header("Player - information")]
	public Transform Player;
	private int playerposition;
	private Player PlayerHealth;
	private int health;
	[Header("Panels")]
	public GameObject GamePanel;	
	public GameObject PausePanel;
	public GameObject EndPanel;
	public GameObject HTPPanel;
	public GameObject PauseCanvas;

	[Header("Buttons")]
	public Button pausebt;

	[Header("Text")]
	public Text UnpauseText;
	public TextMeshProUGUI TXT_Distance;
	[Header("Ads Settings")]
	private string Google_ID = "3848575";
	private string placemenId = "BannerAD";
	private bool TestMode = false;
	private bool adshown = false;

	void Start()
	{
		adshown = false;
		if (PlayerPrefs.GetInt("FirstTime").Equals(0))
		{			
			HTPPanel.SetActive(true);
			Time.timeScale = 0;
		}


		PlayerHealth = Player.GetComponent<Player>();

		Advertisement.Initialize(Google_ID, TestMode);
		//Advertisement.Banner.Show("BannerAD");
		//StartCoroutine(ShowBannerWhenReady());

//		Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);



	}
	void Update()
	{
		health = PlayerHealth.health;
		if (health == 0 || Player.transform.position.y < -4f)
		{
		
			GameOver();
			adshown = true;
		}
	}
	public void PauseGame()
	{
		Time.timeScale = 0;
		PausePanel.SetActive(true);
		pausebt.interactable = false;
	}
	public void UnPauseGame()
	{
		PauseCanvas.SetActive(false);
		GamePanel.SetActive(true);


		StartCoroutine(getReady());
	}
	public void GameOver()
	{
		if (!adshown)
		{
			EndPanel.SetActive(true);
			GamePanel.SetActive(false);
			TXT_Distance.text = "" + (int)(Player.transform.position.x / 10);

			if (Advertisement.IsReady() && Random.Range(1, 100) > 55)
			{
				Debug.Log("aaaaaaaaaaaaaaaaaaaaa");
				Advertisement.Show();
			}
		}
	}

	IEnumerator getReady()
	{
		Input.multiTouchEnabled = false;
		UnpauseText.text = "3";
		yield return StartCoroutine(WaitForRealSeconds(0.5f));

		UnpauseText.text = "2";
		yield return StartCoroutine(WaitForRealSeconds(0.5f));

		UnpauseText.text = "1";
		yield return StartCoroutine(WaitForRealSeconds(0.5f));

		UnpauseText.text = "!אצ";
		yield return StartCoroutine(WaitForRealSeconds(0.5f));

		UnpauseText.text = "";

		Time.timeScale = 1;
		PausePanel.SetActive(false);
		pausebt.interactable = true;
		PauseCanvas.SetActive(true);
		Input.multiTouchEnabled = true;

	}

	IEnumerator WaitForRealSeconds(float waitTime)
	{
		float endTime = Time.realtimeSinceStartup + waitTime;

		while (Time.realtimeSinceStartup < endTime)
		{
			yield return null;
		}
	}
	private void OnApplicationQuit()
	{
		AssetBundle.UnloadAllAssetBundles(false);
		bool success = Caching.ClearCache();
	}
	public void DisableFirstTime()
    {
		PlayerPrefs.SetInt("FirstTime", 1);
			HTPPanel.SetActive(false);
		Time.timeScale = 1;
	}


/* ShowBannerWhenReady()
{
	while (!Advertisement.IsReady(placemenId))
	{
		yield return new WaitForSeconds(0.5f);
	}
	Advertisement.Banner.Show(placemenId);
}*/
}


