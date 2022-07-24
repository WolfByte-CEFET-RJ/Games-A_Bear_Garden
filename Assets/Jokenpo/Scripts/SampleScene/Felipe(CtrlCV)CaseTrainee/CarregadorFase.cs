using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CarregadorFase : MonoBehaviour
{
	public Animator		_anim;
	public GameObject	_botoesECanvas;


	public void Transicao(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	IEnumerator LoadScene(string SceneName)
	{
		_botoesECanvas.SetActive(false);
		_anim.SetTrigger("Inicio");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneName);
	}
}
