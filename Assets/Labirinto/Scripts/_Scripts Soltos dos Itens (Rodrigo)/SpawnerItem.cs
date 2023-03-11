using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    [SerializeField] private Tabuleiro tab; // Eduardo: Tabuleiro que está na cena
    [SerializeField] private List<Floor> floor; // Eduardo: Lista de Andares
    [SerializeField] private GameObject itemColetavel; // Eduardo: Prefab Capsula
    [SerializeField] private Grid grid; // Eduardo: Grid da cena
    private Vector3 worldPos; // Eduardo: Posicao na unity
    private List<Vector3Int> listPosTile; // Eduardo: Lista da posicao dos Tiles que estão preenchidos com bloco de grama
    private int numSorteado; //Eduardo: Numero sorteado de uma posicao
    public static bool CanSpawn{private get; set;} // Eduardo: Variavel estática de

    private void Start()
    {
        CanSpawn = true;
    }
    private void Update()
    {
        SpawnandoItem();
    }
    
    public void SpawnandoItem()
    {
        var posInicialTile = 0;
        var posFinalTile = tab.tiles.Count;

        listPosTile = floor[0].LoadTiles();
        numSorteado = Random.Range(posInicialTile,posFinalTile);

        worldPos = grid.CellToWorld(listPosTile[numSorteado]);

        if(CanSpawn == true)
        {
            StartCoroutine(SpawnItem());
        }
         
    }

    

    IEnumerator SpawnItem()
    {
        CanSpawn = false;
        yield return new WaitForSeconds(3f);
        Instantiate(itemColetavel,new Vector3(worldPos.x, worldPos.y+0.25f, worldPos.z),Quaternion.identity); 
        yield return null;
    }
}
