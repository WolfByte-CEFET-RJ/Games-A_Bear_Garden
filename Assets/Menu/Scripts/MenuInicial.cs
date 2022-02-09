using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
	[Header("Troca de Cena")]
	public string _nomeDaCena;

	public void TrocaCena()
	{
		/*_carregadorFase.*/Transicao(_nomeDaCena);
	}

	public void Transicao(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	IEnumerator LoadScene(string SceneName)
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneName);
	}

	public void Sair()
	{
		Application.Quit();
	}
}
