using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <Summary>
/// Pression bar loading bar at switching the level
/// </Summary>
public class ProgressSceneLoader : MonoBehaviour
{
	[SerializeField]
	private Text progressText;
	[SerializeField]
	private Slider slider;
	private AsyncOperation operation;
	private Canvas canvas;
	private void Awake()
	{
		canvas = GetComponentInChildren<Canvas>(true);
	}

	public void LoadScene(int sceneName)    // Load the scene based on build index
	{
		UpdateProgressUI(0);
		canvas.gameObject.SetActive(true);
		StartCoroutine(BeginLoad(sceneName));
	}

	private IEnumerator BeginLoad(int sceneName)
	{

        yield return new WaitForSeconds(1.5f);
		operation = SceneManager.LoadSceneAsync(sceneName);

		while (!operation.isDone)
		{
			UpdateProgressUI(operation.progress);
			yield return null;
		}

		UpdateProgressUI(operation.progress);
		operation = null;
		canvas.gameObject.SetActive(false);
	}

	private void UpdateProgressUI(float progress)   // Update the value on Slider
	{
		slider.value = progress;
		progressText.text = (int)(progress * 100f) + "%";
	}
}
