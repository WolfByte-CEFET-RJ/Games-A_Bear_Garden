using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    [SerializeField] private Tabuleiro tab; // Eduardo: Tabuleiro que está na cena
    [SerializeField] private List<Floor> floor; // Eduardo: Lista de Andares
    [SerializeField] private GameObject itemColetavel; // Eduardo: Prefab Capsula
    [SerializeField] private Grid grid; // Eduardo: Grid da cena
    private Vector3 worldPos; // Eduardo: Posicao na unity do primeiro calice
    private Vector3 worldPos2; // Eduardo: Posicao na unity do segundo calice no primeiro instante
    private List<Vector3Int> listPosTile; // Eduardo: Lista da posicao dos Tiles que estão preenchidos com bloco de grama
    
    public List<Vector3> listPosTileCalice; // Eduardo: Lista da posicao de tiles onde os calices estao ocupando

    private static SpawnerItem _Instance; // Instancia privada do objeto spawner

    public static SpawnerItem Instance // DesignPattern: Singleton
    {
        get
        {
            _Instance = FindObjectOfType<SpawnerItem>(); // retorna o primeiro objeto que for encontrado ativo do tipo SpawnerItem para a variavel _Instance                                                                            

            return _Instance; //Retorna a variavel _Instance para a variavel Instance
        }
    }

    private int firstTimeSpawner; //Eduardo: variavel que cria uma condicao de spawn apenas na primeira vez que o spawner for acionado
    public bool CanSpawn{private get; set;} 

    private void Start()
    {
        CanSpawn = true;
        firstTimeSpawner = 0;
    }
    private void Update()
    {
        SpawnandoItem();
    }
    
    public void SpawnandoItem()
    {

        if(CanSpawn == true)
        {
            var posInicialTile = 0;
            var posFinalTile = tab.tiles.Count;
            var numSorteado = Random.Range(posInicialTile,posFinalTile);

            listPosTile = floor[0].LoadTiles();
            worldPos = grid.CellToWorld(listPosTile[numSorteado]);

            StartCoroutine(SpawnItem(firstTimeSpawner, numSorteado));
        }

    }

    

    IEnumerator SpawnItem(int firstTimeSpawner, int numSorteado)
    {
        CanSpawn = false;
        yield return new WaitForSeconds(3f);

        if(firstTimeSpawner == 0) // ou seja, se é a primeira vez que está spawnando
        {
            var numSorteado2 = Random.Range(0,tab.tiles.Count); // variavel declarada

            while(numSorteado == numSorteado2) // se ela for igual, ou seja, de as mesmas posicoes, sorteie o numero novamente até ficar diferente
            {
                numSorteado2 = Random.Range(0,tab.tiles.Count);
                Debug.Log("CALICES NAS MESMAS POSICOES");
            }
            
            Vector3 worldPos2 = grid.CellToWorld(listPosTile[numSorteado2]);
            listPosTileCalice.Add(new Vector3(worldPos2.x, worldPos2.y+0.25f, worldPos2.z));
            Instantiate(itemColetavel,new Vector3(worldPos2.x, worldPos2.y+0.25f, worldPos2.z),Quaternion.identity); 
            firstTimeSpawner = 1;
            this.firstTimeSpawner = firstTimeSpawner;
            
        }

        if(listPosTileCalice!=null)
        {
            foreach(Vector3 posCalices in listPosTileCalice)
            {
                while(posCalices == new Vector3(worldPos.x, worldPos.y+0.25f, worldPos.z))
                {
                    numSorteado = Random.Range(0,tab.tiles.Count);
                    worldPos = grid.CellToWorld(listPosTile[numSorteado]); 
                }
            }
        }


        listPosTileCalice.Add(new Vector3(worldPos.x, worldPos.y+0.25f, worldPos.z));
        Instantiate(itemColetavel,new Vector3(worldPos.x, worldPos.y+0.25f, worldPos.z),Quaternion.identity); 
        yield return null;
    }

    bool ValidaTarget()
    {
        Unit unit = null;
        if(StateMachineController.instance.selectedTile.content!=null)
        {
            unit = StateMachineController.instance.selectedTile.content.GetComponent<Unit>();
        }
        
        if(unit!=null) return true;
        else return false;
    }
}
