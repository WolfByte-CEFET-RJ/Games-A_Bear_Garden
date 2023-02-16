using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animation2D
{
    public string name;
    public float frameRate;
    public float delayStart;
    public List<Sprite> frames;
}
