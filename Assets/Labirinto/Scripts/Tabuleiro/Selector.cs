using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public static Selector instance;
    public Vector3Int position {get{return tile.pos;}}
    public Transform transformSelector;
    public TileLogic tile;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
<<<<<<< HEAD

    //Eduardo --> O selector tem 2 mascaras de colisao, uma delas usa a colisao fisica normal, e a outra se colide com o Trigger(Uma está servindo para verificar um caso de colisao diferente)
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector entrou em colisao com a trapVIlao");
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = false;
=======
            MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of ea90abd (update Comentando os codigos)
        }

       
    }

    private void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector está colidindo com a trapVilao");
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = false;
=======
            MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of ea90abd (update Comentando os codigos)
        }
       
    }

     private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector não está colidindo com a trapVilao");
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = true;
=======
            MoveSelectionState.EnableSpawn = true;
>>>>>>> parent of ea90abd (update Comentando os codigos)
        }

        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor colidiu com o bloco");
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = false;
=======
            //MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> Stashed changes
        }
    }

     private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor colidindo com o bloco");
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = false;
=======
            //MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> Stashed changes
        }
    }

     private void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor saiu do bloco");
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = true;
=======
            //MoveSelectionState.EnableSpawnBlock = true;
>>>>>>> Stashed changes
        }
    }


=======
>>>>>>> parent of 97a30b4 (update Criacao de spawnar trap dentro da maquina de estados com todos os detalhes corretos)
}
