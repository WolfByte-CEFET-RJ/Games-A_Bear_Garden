using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public static Selector instance;
    public Vector3Int position {get{return tile.pos;}}
    public TileLogic tile;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

        private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector entrou em colisao com a trapVIlao");
           // MoveSelectionState.EnableSpawn = false;
        }
    }

    private void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector está colidindo com a trapVilao");
           // MoveSelectionState.EnableSpawn = false;
        }
    }

     private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag == "TrapVilao")
        {
            Debug.Log("O selector não está colidindo com a trapVilao");
           // MoveSelectionState.EnableSpawn = true;
        }
    }
}
