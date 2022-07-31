using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapLoader : MonoBehaviour
{
    public Unit unitPrefab;
    //Jobs
    //Objetos do map
    //localização das unidades nesse map
    //quais unidades estão nesse mapa
    //
    public static MapLoader instance;
    void Awake()
    {
        instance = this;
    }

}