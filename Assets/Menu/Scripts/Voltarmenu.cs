using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltarmenu : MonoBehaviour
{
      public void voltarMenu (int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
