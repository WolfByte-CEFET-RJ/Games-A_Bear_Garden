using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Carregamento : MonoBehaviour
{
	[Header("Tela de Carregamento")]
	public GameObject _telaCarregamento;
	public Slider	  _slider;
	public Text       _progressoText;

	public void TrocaCena(string SceneName)
	{
		StartCoroutine(LoadAsynchronously(SceneName));
	}

	IEnumerator LoadAsynchronously(string SceneName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
		_telaCarregamento.SetActive(true);

		while (!operation.isDone)
		{
			float progress1 = Mathf.Clamp01(operation.progress / .9f);
			int progress = (int) progress1;
			_slider.value = progress;
			_progressoText.text = progress * 100f + "%";
			Debug.Log(operation.progress);
			
            yield return null;
		}
	}
}
