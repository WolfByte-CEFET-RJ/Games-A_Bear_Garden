using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle01 : MonoBehaviour
{
    // public Animator anim;
    [SerializeField]
    public float Velocidade = 1.0f;
    [SerializeField]
    public int Vidas01 = 3;
    public bool Jogador01vivo;
    private Vector3 InputDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        Jogador01vivo = true;
    }

   
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        // anim.SetFloat("Horizontal",movement.x);
       // anim.SetFloat("Vertical",movement.y);
       // anim.SetFloat("Velocidade",movement.magnitude);
    
       transform.position = transform.position + movement * Velocidade * Time.deltaTime;
    }
   
}
