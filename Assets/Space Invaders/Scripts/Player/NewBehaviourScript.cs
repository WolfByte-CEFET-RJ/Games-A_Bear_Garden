using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float horizontalI;
    public float speed;
    public float verticalI;

    void Start()
    {

        
    }

    void Update()
    {

        horizontalI = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalI * speed * Time.deltaTime);

        verticalI = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalI * speed * Time.deltaTime);

    }
}
