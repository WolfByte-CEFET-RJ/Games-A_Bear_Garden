using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TurnoDoVilao : State
{
    [SerializeField] Tilemap tiles; // Conjuntos de tiles(TileMap)
    //[SerializeField] GameObject trapVilao; // Prefab da armadilha do vilao
    GameObject _objetoExt;  //Rodrigo --> variável para capturar o GameObject "MapLoader"
    MapLoader _scriptExt;   //Rodrigo --> variável para capturar o script "MapLoader" do GameObject "MapLoader"
    [SerializeField] Armadilha trapV;  //Rodrigo --> variável tipo Armadilha: script criado para fornecer informações sobre as armadilhas e auxiliar no spawn
    Tile tile; // Um Tile(uma célula)
    bool spawnou = false;
    GameObject holder;  //Rodrigo --> variável para criar uma "pasta" de armadilhas no hierarchy

    public Vector3Int LocationOfCell{get; private set;} // Localizacao de cada célula do meu TileMap

    void Awake()
    {
        //instance = this;
        holder = new GameObject("Armadilhas");

        _objetoExt = GameObject.Find("MapLoader");  //Rodrigo --> capturando o GameObject "MapLoader"
        _scriptExt = _objetoExt.GetComponent<MapLoader>();  //Rodrigo --> pegando o script "MapLoader" do GameObject "MapLoader"
        trapV = _scriptExt._trapV; //Rodrigo --> atribuindo a variável "_trapV" à variável "trapV" desse script
    }

    void Start()
    {
        holder.transform.parent = Tabuleiro.instance.transform;    
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(PlaceTrap());
    }

    IEnumerator PlaceTrap(){

        //SpawnTrap();
        //List<TileLogic> posSelector = new List<TileLogic>();    //pra depois
        //posSelector.Add(machine.selectedTile);
        
        //TileLogic ti = Tabuleiro.GetTile(new Vector3Int(3, 3, 0));
        Armadilha trap = CreateTrap(new Vector3Int(-2, -5, 0), "armadilha 1");  //Rodrigo --> chamando o método "CreateTrap" e passando os valores de posição (fixo por enquanto) e nome da armadilha (utiilzado pelo holder)
        yield return null;
        machine.ChangeTo<ChooseActionState>();  //Rodrigo --> volta ao "ChooseActionState" da máquina de estado
    }

    public Armadilha CreateTrap(Vector3Int pos, string name)    //Rodrigo --> método que cria a trap
    {

        TileLogic t = Tabuleiro.GetTile(pos);   //Rodrigo --> posição do TileLogic informada pelo vetor de entrada
        Armadilha _trap = Instantiate(trapV, t.worldPos, Quaternion.identity, holder.transform);    //Rodrigo --> armadilha instanciada e atribuída a "_trap" do tipo Armadilha
        _trap.tile = t; //Rodrigo --> o tile que ela está
        _trap.name = name;  //Rodrigo --> o nome do Objeto
        return _trap;
    }

    /*void SpawnTrap()
    {
        Debug.Log("Its A Trap!");
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Transforma a posicao do mouse da tela para a posicao do mouse no mundo da unity
        LocationOfCell = tiles.WorldToCell(mousePosWorld); // Basicamente vai retornar o valor de cada célula do timemap através da posicao do mouse
        
        if(tiles.GetTile(LocationOfCell) )
        {
            Vector3 posTrap = tiles.CellToWorld(LocationOfCell); // posicao das celulas no mundo da unity, que será onde a armadilha será spawnada

            Debug.Log("Tile encontrado na pos relacionado a Celula: "+LocationOfCell+" do TileMap Andar01");
            Debug.Log("Tile encontrado na pos relacionado ao mundo Unity: "+tiles.CellToWorld(LocationOfCell)+" do TileMap Andar01");
            
            Instantiate(trapVilao,new Vector3(posTrap.x, posTrap.y+0.25f, posTrap.z+2), Quaternion.identity); // os valores sao somados ao eixo y e z para corrigir o bug da posicao
            spawnou = true;
            return;
        }
        else
        {
            Debug.Log("Tile nao encontrado no TileMap Andar01");
            return;
        }
        
    }*/
}
