using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Resolution : MonoBehaviour{

    List<int> widths = new List<int>() {568, 960, 1280, 1920};
    List<int> heights = new List<int>() {329, 540, 800, 1080};
   
    public void SetScreenSize(int index) {
        bool fullscreen = Screen.fullScreen;
        int widht = widths[index];
        int height = heights[index];
        Screen.SetResolution(widht, height, fullscreen);
    }
}
