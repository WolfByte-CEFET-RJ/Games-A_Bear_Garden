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
    
    /*Tile tile; // Um Tile(uma célula)
    bool spawnou = false;*/
    
    private int idArmadilha; // Eduardo --> números para identificar as armadilhas pelos seus nomes
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
        StartCoroutine(PlaceTrap()); //Eduardo --> Ao estado ser iniciado, é inicializado a corrotina de spawnar a trap do vilao
    }

    IEnumerator PlaceTrap(){
        Armadilha trap = CreateTrap("armadilha "+ idArmadilha.ToString());  //Rodrigo --> chamando o método "CreateTrap" passando o nome da armadilha (utiilzado pelo holder)
        yield return null;
        machine.ChangeTo<ChooseActionState>();
    }

    public Armadilha CreateTrap(string name)    //Rodrigo --> método que cria a trap
    {

        TileLogic t = Tabuleiro.GetTile(Selector.instance.position); // Eduardo --> A variavel t pega a posicao do tile do tabuleiro na posicao que o selector está
        idArmadilha++; // Eduardo --> sempre que uma armadilha for criada, o id vai ser aumentado para que caso ocorra de ser criado uma nova armadilha, essa outra armadilha criada ser identificada por outro número
        if(Selector.instance.spriteRenderer.sortingOrder == 300 ) // Eduardo --> Se o selector está na ordem de renderizacao do andar 01...
        {
            Armadilha _trap = Instantiate(trapV, new Vector3(t.worldPos.x,t.worldPos.y+0.5f,t.worldPos.z), Quaternion.identity, holder.transform);    //Rodrigo e Eduardo --> armadilha instanciada e atribuída a "_trap" do tipo Armadilha, o new Vector3 da posicao da armadilha instanciada é utilizada para spawna-la na posicao correta no andar 1
            _trap.tile = t; //Rodrigo --> o tile que ela está
            _trap.name = name;  //Rodrigo --> o nome do Objeto
            return _trap; // Eduardo --> retorna o objeto trap para conseguir acessar as informacoes do mesmo
        }
        
        return null;
        
        
        /*Armadilha _trap = Instantiate(trapV, t.worldPos, Quaternion.identity, holder.transform);    //Rodrigo --> armadilha instanciada e atribuída a "_trap" do tipo Armadilha
        _trap.tile = t; //Rodrigo --> o tile que ela está
        _trap.name = name;  //Rodrigo --> o nome do Objeto
        return _trap;*/
    }
}
