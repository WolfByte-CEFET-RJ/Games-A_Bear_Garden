using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Tabuleiro : MonoBehaviour
{
    public Dictionary<Vector3Int, TileLogic> tiles;// Dicionário de Posição
    public List<Floor> floors;// Andares do Labirinto
    public static Tabuleiro instance;
    [HideInInspector]
    public Grid grid;
    public List<Tile> casaSeleçao;
    public Vector3Int[] dirs = new Vector3Int[4]
    {
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.right,
        Vector3Int.left
    };
    
    void Awake()
    {
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }

    public IEnumerator InitSequence(LoadState loadState)
    {
        yield return StartCoroutine(LoadFloors(loadState));
        yield return null; // Continua o carregamento do labirinto no proximo frame
        Debug.Log("Foram criados "+tiles.Count+" tiles");
        ShadowOrdering();
        yield return null;
        // floors[2].casaSeleçao.SetTile(new Vector3Int(-5,-5,0), casaSeleçao[0]); //teste para verificação de casaSeleção 
    }
    IEnumerator LoadFloors(LoadState loadState)
    {
        for(int i=0; i<floors.Count; i++)
        {
            List<Vector3Int> floorTiles = floors[i].LoadTiles();
            yield return null;// Continua o carregamento do labirinto no proximo frame
            for(int j=0; j<floorTiles.Count; j++)
            {
                if(!tiles.ContainsKey(floorTiles[j]))
                {
                    CreateTile(floorTiles[j], floors[i]);// Posição e andar do Tile.
                }
            }
        }
    }

    public void CreateTile(Vector3Int pos, Floor floor)
    {
        Vector3 worldPos = grid.CellToWorld(pos);// posição do tile no Tabuleiro
        worldPos.y+= (floor.tilemap.tileAnchor.y/2)-0.5f;
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);
        tiles.Add(pos, tileLogic);
    }

    void ShadowOrdering()
    {
        foreach(TileLogic t in tiles.Values)
        {
            int floorIndex = floors.IndexOf(t.floor);
            floorIndex -= 2;// Se houver mais de 2 andares, a ordem de renderização é diferente

            if(floorIndex >=floors.Count || floorIndex <0)
            {
                continue;
            }
            Floor floorToCheck = floors[floorIndex];

            Vector3Int pos = t.pos;
            IsNECheck(floorToCheck,t ,pos+Vector3Int.right);// Caso o personagem esteja a esquerda ordena o tile da direita
            IsNECheck(floorToCheck,t ,pos+Vector3Int.up);// Caso o personagem esteja a baixo ordena o tile da cima
            IsNECheck(floorToCheck,t ,pos+Vector3Int.right+Vector3Int.up);// Caso o personagem esteja a nordeste ordena o tile da
        }
    }

    void IsNECheck(Floor floor, TileLogic t, Vector3Int NEPosition)
    {
        if(floor.tilemap.HasTile(NEPosition))
        {
            t.contentOrder = floor.order;// Ordena o tile ao andar do personagem
        }
    }
    public static TileLogic GetTile(Vector3Int pos)
    {
        TileLogic tile = null;
        instance.tiles.TryGetValue(pos, out tile);
        return tile;
    }

    public void SelecionarTiles(List<TileLogic> tiles, int AliancaIndex)// Irá fazer a verificação dos Tiles e Colocar a Cor correspondente a Aliança
    {
        for(int i=0; i<tiles.Count; i++)
        {
            tiles[i].floor.casaSeleçao.SetTile(tiles[i].pos, casaSeleçao[AliancaIndex]);
        }
    }

    public void DeselecionarTiles(List<TileLogic> tiles)// Ele irá desfazer a ação ou tarefa anterior
    {
        for(int i=0; i<tiles.Count; i++)
        {
            tiles[i].floor.casaSeleçao.SetTile(tiles[i].pos, null);
        }
    }

    public List<TileLogic> Search(TileLogic start)//
    {
        List<TileLogic> tilesSearch = new List<TileLogic>();
        Movimento m = Turnos.unit.GetComponent<Movimento>();// Carrega o Movimento das unidades

        tilesSearch.Add(start);
        LimpezaSearch();

        Queue<TileLogic> checkNext = new Queue<TileLogic>();
        Queue<TileLogic> checkNow = new Queue<TileLogic>();

        start.distancia = 0;
        checkNow.Enqueue(start);

        while(checkNow.Count>0)
        {
            TileLogic t = checkNow.Dequeue();
            for(int i=0;i<4;i++)
            {
                TileLogic next = GetTile(t.pos + dirs[i]);// analisa os 4 Tiles em volta da Unidade
                if(next == null || next.distancia<=t.distancia+1 || t.distancia+1>3 || m.ValidacaoMovimento(t, next) )
                // verifica se o tile existe, se o caminho é o melhor para percorrer e evita Andares mais altos(1 para o 3)
                {
                    continue;
                }
                //Checagem a mais
                next.distancia = t.distancia+1;
                next.prev = t;
                checkNext.Enqueue(next);
                tilesSearch.Add(next);
            }
            if(checkNow.Count == 0)
            {
                SwapReference(ref checkNow, ref checkNext);// Troca as referencia para que ela não sejam perdidas
            }
        }
        return tilesSearch;
    }
    void SwapReference(ref Queue<TileLogic> now, ref Queue<TileLogic> next)// Troca as referencia em uma variável temporária
    {
        Queue<TileLogic>temp = now;
        now = next;
        next = temp;
    }
    void LimpezaSearch()// 
    {
        foreach(TileLogic t in tiles.Values)
        {
            t.prev = null;
            t.distancia = int.MaxValue;
        }
    }
}
