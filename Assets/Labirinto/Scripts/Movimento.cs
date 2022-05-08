using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
   
    public bool teste;
    public Vector3Int destino;
    SpriteRenderer SR;
    Transform pulo;
    TileLogic tileAtual;

    void Start()
    {
        pulo = transform.Find("Jumper");
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

        Vector3 startPos = transform.position;
        Vector3 endPos = t.worldPos;
        float totalTime=1;
        float tempTime=0;

        if(tileAtual == null)
        tileAtual = t;
        if(tileAtual.floor != t.floor)
        StartCoroutine(Jump(t, totalTime));

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
    IEnumerator Jump(TileLogic t, float totalTime)
    {
        Vector3 halfwayPos;
        Vector3 startpos = halfwayPos = pulo.localPosition;// Movimenta a Posição local ddo personagem
        halfwayPos.y += 0.5f;// Adiciona a distancia de pulo do personagem 
        float tempTime = 0;

        if(tileAtual.floor.tilemap.tileAnchor.y < t.floor.tilemap.tileAnchor.y)
        {
            SR.sortingOrder = t.contentOrder;
        }

        while(pulo.localPosition!=halfwayPos)
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / (totalTime/2);// Ao chegar ao ponto mais alto do pulo isso deve acontecer em metade do tempo.
            pulo.localPosition = Vector3.Lerp(startpos, halfwayPos, perc);
            yield return null;
        }
        tempTime = 0;
        while(pulo.localPosition!=startpos)//Caminho contrario do pulo
        {
            tempTime += Time.deltaTime;
            float perc = tempTime / (totalTime/2);
            pulo.localPosition = Vector3.Lerp(halfwayPos,startpos, perc);
            yield return null;
        }
    }

}
