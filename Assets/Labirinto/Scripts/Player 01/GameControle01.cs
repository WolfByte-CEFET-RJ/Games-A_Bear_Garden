using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControle01 : MonoBehaviour
{
    public Transform[] Casa; //
    [SerializeField]
    private int CasaAtual;
    public int Dados;
    public Transform[] dados;
    public Transform spawn;
    public Transform DadosAtual;
     //
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(CasaAtual == 5)
        {
            
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10,70,100,20),"Dado:"+ Dados);
        if(GUI.Button(new Rect(10,10,150,50),"Jogar"))
        {
            Jogar();
        }
    }
    void Jogar()
    {
        Dados=Random.Range(1,6);
        CasaAtual=CasaAtual+Dados;
        if(CasaAtual < Casa.Length)
        {
            transform.position=Casa[CasaAtual].position;
            Spawn();
        }
        else
        {
            CasaAtual=64;
            transform.position=Casa[CasaAtual].position;
            Spawn();
        }
    }
    void Spawn()
    {
        Destroy(DadosAtual.gameObject);
        DadosAtual=Instantiate(dados[Dados],spawn.transform.position,dados[Dados].rotation);
    }
}
