using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public class Spawner : MonoBehaviour
    {
        [Header("Objectos")]
        public GameObject _objectToSpawn;
        public GameObject _spawnToObject;

        void Start()
        {
            Instantiate(_objectToSpawn, _spawnToObject.transform);
        }
    }
}