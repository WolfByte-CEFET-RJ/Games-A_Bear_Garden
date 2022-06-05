using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class record : MonoBehaviour
{

    public Text vidaATxt, vidaITxt;

    void Start()
    {
        
    }

    void Update()
    {
        vidaATxt.text = PlayerPrefs.GetFloat("vida_amiga").ToString();
        vidaITxt. text = PlayerPrefs.GetFloat("vida_inimiga").ToString();
    }
}
