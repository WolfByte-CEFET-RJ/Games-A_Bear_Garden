using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpcao : MonoBehaviour
{
    public bool _estaPausado;
    public GameObject _pausePainel;
    public GameObject _menuOpcao;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _estaPausado = !_estaPausado;   //Ferrari  Modifica a variavel para seu contrario
            Time.timeScale = 1;
            _pausePainel.SetActive(false);
            _menuOpcao.SetActive(false);
        }    
    }
}
