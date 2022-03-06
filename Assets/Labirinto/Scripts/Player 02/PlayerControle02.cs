using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle02 : MonoBehaviour
{
    // public Animator anim;
    public float Velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal2"),Input.GetAxis("Vertical2"),0f);
        // anim.SetFloat("Horizontal",movement.x);
       // anim.SetFloat("Vertical",movement.y);
       // anim.SetFloat("Velocidade",movement.magnitude);

        transform.position = transform.position + movement * Velocidade * Time.deltaTime;
    }
}
