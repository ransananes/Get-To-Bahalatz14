using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Loader : MonoBehaviour
{
	public GameObject Panel_Loading;
	public Slider slider;
	//public AudioSource AudioSource;
	//public AudioClip AudioLoad;
	public void LoadLevel(int sceneindex)
	{

		//operation.progress;
		//	A.PlayOneShot(Load, 1f);
		StartCoroutine(LoadASynchronously(sceneindex));

	}

	IEnumerator LoadASynchronously(int sceneindex)
	{		
		Time.timeScale = 1;
		Panel_Loading.SetActive(true);
		yield return new WaitForSeconds(0.4f);


		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);


		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			yield return null;
		}
	}

}
