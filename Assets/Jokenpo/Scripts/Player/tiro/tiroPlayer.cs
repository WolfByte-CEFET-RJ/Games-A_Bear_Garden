using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPlayer : MonoBehaviour
{

    private float X, Y, Z;
    public GameObject tiroPrefab;
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        X = player.transform.position.x;
        Y = player.transform.position.y;
        Z = player.transform.position.z;

        if(Input.GetKeyDown(KeyCode.W)){
            GameObject tempPrefab = Instantiate(tiroPrefab) as GameObject;
            tempPrefab.transform.position = new Vector3(X, Y, Z);
        }        
       
    }

}
