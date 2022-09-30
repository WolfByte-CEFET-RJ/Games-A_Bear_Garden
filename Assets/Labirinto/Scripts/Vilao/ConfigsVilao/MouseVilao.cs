using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseVilao : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject instance;

    public bool EnableSpawnTrap{get; set;} // Propriedade que permite se uma trap será spawnada ou não

    void Awake() {
        EnableSpawnTrap = true;
        instance = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition); // fazendo com que meu objeto que acompanha o cursor sempre esteja na pos do cursor
        
        
    }

    private void OnTriggerEnter2D(Collider2D col) // verifica se meu objeto que está na mesma posicao do cursor colidiu com uma trapVilao
    { 
        if(col.tag == "TrapVilao")
        {
            Debug.Log("Colidiu o mouse com a trapVilao");
            EnableSpawnTrap = false; //nao permite o spawn da trap vilao se ocorrer colisao entre meu objeto que imita o cursor e a trapVilao
            
        }
    }
    private void OnTriggerStay2D(Collider2D col) // está verificando se meu objeto que está na mesma posicao do cursor está colidindo com uma trapVilao
    {
         if(col.tag == "TrapVilao")
        {
            Debug.Log("Está colidindo o mouse com a trapVilao");//nao permite o spawn da trap vilao se estiver ocorrendo colisao entre meu objeto que imita o cursor e a trapVilao
            EnableSpawnTrap = false;
            
        }
    }

    private void OnTriggerExit2D(Collider2D col)// verifica quando meu objeto que está sempre na mesma posicao do cursor sair da colisao com uma trapVilao
    {
        if(col.tag == "TrapVilao")
        {
            Debug.Log("O mouse saiu da colisao com a trapVilao");
            EnableSpawnTrap = true;// quando meu objeto que imita o cursor sai da colisao com a trapVilao, ele pode spawnar traps em outros tiles
            
        }
    }

    

    
    

    
        
    
        
    
}
