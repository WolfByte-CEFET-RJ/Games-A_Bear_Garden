using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int life;

    [SerializeField] private char type;

    private Rigidbody2D rig;

    [SerializeField] private AudioClip powerUpSound;
    private AudioSource audioS;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.down * speed;
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            OnPowerUpSound();
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
                col.GetComponent<Weapon>().StartCoroutine(col.GetComponent<Weapon>().SetFireRate(1.5f));
            }
        }
    }

    void OnPowerUpSound()
    {
        GetComponent<PolygonCollider2D>().enabled = false;//Desativei esses 2 componentes para dar uma impressao de que eles sumiram da tela, para
        GetComponent<SpriteRenderer>().enabled = false; //Manter o Audio Source ativado ate o fim do Sfx do power up. Quando eu so destruia o obj,
        audioS.PlayOneShot(powerUpSound);//Nao dava tempo do som ir ate o final
        Destroy(gameObject, powerUpSound.length);
    }

}
