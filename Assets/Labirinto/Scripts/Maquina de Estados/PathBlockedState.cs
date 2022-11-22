using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;
public class PathBlockedState : State
{
    // Start is called before the first frame update
    GameObject _objetoExt;  //Rodrigo --> variável para capturar o GameObject "MapLoader"
    MapLoader _scriptExt;   //Rodrigo --> variável para capturar o script "MapLoader" do GameObject "MapLoader"
    BlockingBlock bloco;
    void Awake()
    {
         
        _objetoExt = GameObject.Find("MapLoader");  //Rodrigo --> capturando o GameObject "MapLoader"
        _scriptExt = _objetoExt.GetComponent<MapLoader>();  //Rodrigo --> pegando o script "MapLoader" do GameObject "MapLoader"
    }
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(BlockPath()); // Eduardo --> Iniciando a Rotina BlockPath
    }

    IEnumerator BlockPath()
    {
        TileBlockPath(); // Eduardo --> Chamando o metodo que irá spawnar o bloco que atrapalhará o caminho do player
        yield return null;
        machine.ChangeTo<ChooseActionState>();
    }

    public void TileBlockPath()
    {
        TileLogic t = Tabuleiro.GetTile(Selector.instance.position); // Eduardo --> A variavel t pega a posicao do tile do tabuleiro na posicao que o selector está
        bloco = Instantiate(_scriptExt.block,new Vector3(t.worldPos.x+0.61f,t.worldPos.y+1.29f,t.worldPos.z-1), Quaternion.identity); // Eduardo --> Instanciando o prefab do bloco que atrapalha o caminho do player em uma posicao corrigida para ser spawnada corretamente
         
    }
}
