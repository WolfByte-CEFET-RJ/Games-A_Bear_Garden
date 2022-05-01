using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
   
    public bool teste;
    public Vector3Int destino;
    SpriteRenderer SR;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(teste)
        {
            teste = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        yield return null;
        TileLogic t = Tabuleiro.instance.tiles[destino];
        transform.position = t.worldPos;

        Vector3 startPos = transform.position;
        Vector3 endPos = t.worldPos;
        float totalTime=1;
        float tempTime=0;

        while(transform.position != endPos)
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / totalTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            yield return null;
        }

        

        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }
}
