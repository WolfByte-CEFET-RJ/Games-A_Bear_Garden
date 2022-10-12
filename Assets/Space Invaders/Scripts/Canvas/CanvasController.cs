using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
  
    public void ToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
