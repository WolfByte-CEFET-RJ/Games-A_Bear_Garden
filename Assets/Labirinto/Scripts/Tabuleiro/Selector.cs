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

    //Eduardo --> O selector tem 2 mascaras de colisao, uma delas usa a colisao fisica normal, e a outra se colide com o Trigger(Uma está servindo para verificar um caso de colisao diferente)
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector entrou em colisao com a trapVIlao");
            MoveSelectionState.EnableSpawn = false;
        }

       
    }

    private void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector está colidindo com a trapVilao");
            MoveSelectionState.EnableSpawn = false;
        }
       
    }

     private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector não está colidindo com a trapVilao");
            MoveSelectionState.EnableSpawn = true;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor colidiu com o bloco");
          // MoveSelectionState.EnableSpawnBlock = false;
        }
    }

     private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor colidindo com o bloco");
          // MoveSelectionState.EnableSpawnBlock = false;
        }
    }

     private void OnTriggerExit2D(Collider2D col) {
        if(col.CompareTag("BlockTrigger"))
        {
            Debug.Log("Seletor saiu do bloco");
          // MoveSelectionState.EnableSpawnBlock = true;
        }
    }


}
