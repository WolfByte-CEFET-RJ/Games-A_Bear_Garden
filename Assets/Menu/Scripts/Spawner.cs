using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Header("Objeto")]
    public GameObject _objet, _bjt;
    public GameObject _local1, _local2;

    public void ShowPlace()
    {
        Instantiate(_objet, _local2.transform.position, Quaternion.identity);
        Instantiate(_bjt, _local1.transform.position, Quaternion.identity);
    }

    public void SpawnObjetos()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                _bjt = Instantiate(_bjt);
                _bjt.transform.position = _local1.transform.position;
                Debug.Log("local1");
                break;
            case 1:
                _objet = Instantiate(_objet);
                _objet.transform.position = _local2.transform.position;
                Debug.Log("local2");
                break;
        }
    }
}
