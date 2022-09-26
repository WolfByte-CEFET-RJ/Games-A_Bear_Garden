using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SelecionandoFase : MonoBehaviour
{
    [Header("Fases")]
    public int _lab;
    public int _ppt;
    public int _naves;
    [SerializeField] Text _labText;
    [SerializeField] Text _pptText;
    [SerializeField] Text _navesText;

    

    public List<string> ids = new List<string>();
    private bool ativado_1 = false;
    private bool ativado_2 = false;
    private bool ativado_3 = false;

    //[Header("Mapa")]
    //public Tilemap _tiles;
    //public Tile _tile;
    //public Vector3Int _local;

    //public static SelecionandoFase Instance { get; private set; }

    public void Start()
    {
        _labText.text = " ";
        _pptText.text = " ";
        _navesText.text = " ";
    }


    public void Update() 
    {
        VerificaLista();
    }


    public void VerificaLista() 
    {
        for (int i = 0; i < ids.Count; i++) {
            int texto = i + 1;
            if (ids[i] == "ID_lab") {
                _labText.text = texto.ToString();
            } else if (ids[i] == "ID_ppt"){
                _pptText.text = texto.ToString();
            } else if (ids[i] == "ID_naves") {
                _navesText.text = texto.ToString();
            }
        }
    }

    public void OnClickButton(Button button) 
    {
        if (button.name == "_labButton") {
            if (ativado_1 == false) {
                ids.Add("ID_lab");
            } else {
                ids.Remove("ID_lab");
                _labText.text = " ";
            }
            ativado_1 = !ativado_1;
        }

        if (button.name == "_pptButton") {
            if (ativado_2 == false) {
                ids.Add("ID_ppt");
            } else {
                ids.Remove("ID_ppt");
                _pptText.text = " ";
            }
            ativado_2 = !ativado_2;
        }

        if (button.name == "_navesButton") {
            if (ativado_3 == false) {
                ids.Add("ID_naves");
            } else {
                ids.Remove("ID_naves");
                _navesText.text = " ";  
            }
            ativado_3 = !ativado_3;
        }
    }

    public void Fase1()
    {
        if (ids[0] == "ID_lab")
        {
            SceneManager.LoadScene("Lab");
        }

        if (ids[0] == "ID_ppt")
        {
            SceneManager.LoadScene("ppt");
        }

        if (ids[0] == "ID_naves")
        {
            SceneManager.LoadScene("Space");
        }
    }

    public void Fase2()
    {
        if (ids[1] == "ID_lab")
        {
            SceneManager.LoadScene("Lab");
        }

        if (ids[1] == "ID_ppt")
        {
            SceneManager.LoadScene("ppt");
        }

        if (ids[1] == "ID_naves")
        {
            SceneManager.LoadScene("Space");
        }
    }

    public void Fase3()
    {
        if (ids[2] == "ID_lab")
        {
            SceneManager.LoadScene("Lab");
        }

        if (ids[2] == "ID_ppt")
        {
            SceneManager.LoadScene("ppt");
        }

        if (ids[2] == "ID_naves")
        {
            SceneManager.LoadScene("Space");
        }
    }
    /*
    Definir qual o tipo de mapa que vamos usar;

    Atribuir uma fase ao botao/tile - + definir a cor do botão de acordo com o estado da fase;

    Collider em volta da fase;

    Collider vai selecionar a fase - trigger (espaço/enter)

    Entrar na condicional: Qual a condição da fase;

    Chama o resultado(se tiver como passada não acontece nada);
    */
}
