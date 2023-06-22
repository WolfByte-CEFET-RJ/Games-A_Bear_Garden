using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    const float MoveSpeed = 0.5f;
    const float jumpHeight = 0.5f;

    public List<Vector3Int> path;

    SpriteRenderer SR;
    Transform jumper;
    TileLogic tileAtual;
    private AudioSource AS;

    [SerializeField] private AudioClip playerWalkSfx;
    [SerializeField] private AudioClip bossWalkSfx;
    void Awake()
    {
        jumper = transform.Find("Jumper");
        SR = GetComponentInChildren<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (gameObject.name.StartsWith("Jogador"))//Joel-->Atribuir o clipe que sera tocado de acordo com o nome do objeto        
            AS.clip = playerWalkSfx;
        
        else if (gameObject.name.StartsWith("Vilao"))       
            AS.clip = bossWalkSfx;     
    }

    public void PlayWalkSound()//Tocar o clipe a partir do MoveSequenceState, porque se fosse daqui, ele ficaria resetando varias vezes
    {
        AS.Play();
    }
    public void StopSound()
    {
        AS.Stop();
    }
    public IEnumerator Move(List<TileLogic> path)// Divide a função ou tarefa em vários frames
    {
       tileAtual = Turnos.unit.tile;
       tileAtual.content = null;
      
        for (int i = 0; i < path.Count; i++)
        {
           TileLogic to = path[i];
            if(tileAtual.floor!=to.floor)
            {
                yield return StartCoroutine(Jump(to));
            }
            else
            {
                //Debug.Log("Tocar passos");               
                yield return StartCoroutine(Walk(to));// Espera o fim da animação (Walk)
            }
        }
    }
    IEnumerator Walk(TileLogic to)
    {
        int id = LeanTween.move(transform.gameObject,to.worldPos, MoveSpeed).id;// cria um ID único enquanto esta se movendo(pega a posição desse objeto e o leva para a posição final em X tempo )
        tileAtual = to;

        yield return new WaitForSeconds(MoveSpeed*0.5f);// espera o tempo de movimento
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id)!=null)
        {
            yield return null;//pula para o proximo frame
        }
        //to.content = this.gameObject;
    }

    IEnumerator Jump(TileLogic to)
    {
        int id1 = LeanTween.move(transform.gameObject,to.worldPos, MoveSpeed).id;
        LeanTween.moveLocalY(jumper.gameObject,jumpHeight, MoveSpeed*0.5f).//Posição Local ou Pulo na metade do tempo da animação
        setLoopPingPong(1).setEase(LeanTweenType.easeInOutQuad);// Variações de velocidade para a animação (tipo de animação com base em tipos de curvas ou constantes)

        float timerOrderUpdate = MoveSpeed;//Utilizo o MoveSpeed para atualizar a ordem do sprite, quando o personagem estiver pulando ou caindo apos o pulo.
        if(tileAtual.floor.tilemap.tileAnchor.y > to.floor.tilemap.tileAnchor.y)
        {
            timerOrderUpdate*=0.85f;// ordem dos tiles com os pulos
        }
        else
        {
            timerOrderUpdate*=0.2f;
        }
        yield return new WaitForSeconds(timerOrderUpdate);
        tileAtual = to;
        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id1)!=null)
        {
            yield return null;
        }
        //to.content = this.gameObject;
    }
    public virtual bool ValidacaoMovimento(TileLogic from, TileLogic to)
    {
        if(Mathf.Abs(from.floor.altura-to.floor.altura)>1 || to.content!=null )
        // verifica a diferença de altura dos Andares 1, 2 ou 3 dos tiles e se existe unidades neles
        {
            return true;
        }
        return false;
    }
}
