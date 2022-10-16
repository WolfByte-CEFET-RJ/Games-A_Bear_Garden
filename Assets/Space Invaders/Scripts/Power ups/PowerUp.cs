using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int life;

    [SerializeField] private char type;
    private Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(gameObject);
            if(type == 'L')
            {
                //Debug.Log("Aumentar vida");
                IHealth effect = col.gameObject.GetComponent<IHealth>();
                if (effect != null)
                {
                    effect.Damage(-life); //Achei mais proveitoso usar o Damage(int) do IHealth do que criar outro metodo na interface 
                }//Apenas para aumentar a vida
            }
            else if(type == 'S')
            {
                col.GetComponent<Weapon>().StartCoroutine(col.GetComponent<Weapon>().SetFireRate(10f));
            }
        }
    }

}
