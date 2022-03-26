using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
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
			float progress = Mathf.Clamp01(operation.progress / .9f);
			_slider.value = progress;
			_progressoText.text = progress * 100f + "%";

			yield return null;
		}	
	}

	public void Sair()
	{
		Application.Quit();
	}
}
