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
<<<<<<< HEAD
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = false;
=======
            MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of ea90abd (update Comentando os codigos)
=======
           // MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
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
<<<<<<< HEAD
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = false;
=======
            MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of ea90abd (update Comentando os codigos)
=======
           // MoveSelectionState.EnableSpawn = false;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
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
<<<<<<< HEAD
<<<<<<< HEAD
            //MoveSelectionState.EnableSpawn = true;
=======
            MoveSelectionState.EnableSpawn = true;
>>>>>>> parent of ea90abd (update Comentando os codigos)
=======
           // MoveSelectionState.EnableSpawn = true;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
=======
            MoveSelectionState.EnableSpawn = true;
>>>>>>> parent of ea90abd (update Comentando os codigos)
        }

        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Block"))
        {
            Debug.Log("Seletor colidiu com o bloco");
<<<<<<< HEAD
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = false;
=======
            //MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> Stashed changes
=======
           // MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
        }
    }

     private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("Block"))
        {
            Debug.Log("Seletor colidindo com o bloco");
<<<<<<< HEAD
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = false;
=======
            //MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> Stashed changes
=======
           // MoveSelectionState.EnableSpawnBlock = false;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
        }
    }

     private void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("Block"))
        {
            Debug.Log("Seletor saiu do bloco");
<<<<<<< HEAD
<<<<<<< Updated upstream
          // MoveSelectionState.EnableSpawnBlock = true;
=======
            //MoveSelectionState.EnableSpawnBlock = true;
>>>>>>> Stashed changes
=======
           // MoveSelectionState.EnableSpawnBlock = true;
>>>>>>> parent of 5cd038f (update Corrigindo detalhes relacionado ao mecanismo de colisao dos blocos e trap Vilao)
        }
    }


=======
>>>>>>> parent of 97a30b4 (update Criacao de spawnar trap dentro da maquina de estados com todos os detalhes corretos)
}
