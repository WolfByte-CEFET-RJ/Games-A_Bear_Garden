using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DelegateModel(object sender, object args);

public class InputController : MonoBehaviour
{
    float hCooldown=0;
    float vCooldown=0;
    float cooldownTimer=0.5f;
    public static InputController instance;

    public DelegateModel OnMove;
    public DelegateModel OnFire;


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Vector3Int moved = new Vector3Int(0, 0, 0);
        if(h!=0)
        {
            moved.x = GetMoved(ref hCooldown, h);
            
        }
        else
        {
            hCooldown = 0;//Reseta o timer depois que para de pressionar o Botão
        }

        if(v!=0)
        {
            moved.y = GetMoved(ref vCooldown, v);
        }
        else
        {
            vCooldown = 0;// Reseta o timer depois que para de pressionar o Botão
        }

        if(moved!=Vector3Int.zero && OnMove!=null)
        {
            OnMove(null, moved);
        }
        if(Input.GetButtonDown("Fire1") && OnFire!=null)
        {
            Debug.Log("Tecla esquerda da mouse pressionada");
            OnFire(null, 1);
        }
         if(Input.GetButtonDown("Fire2") && OnFire!=null)
        {
            Debug.Log("Tecla direita da mouse pressionada");
            OnFire(null, 2);
        }
    }

    int GetMoved(ref float cooldownSum, int value)
    {
        if(Time.time > cooldownSum)
        {
            cooldownSum += Time.time + cooldownTimer;
            return value;
        }
        return 0;
    }
}
