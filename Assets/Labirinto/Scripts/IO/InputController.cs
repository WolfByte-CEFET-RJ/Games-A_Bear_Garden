using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    float hCooldown=0;
    float vCooldown=0;
    float cooldownTimer=0;
    void Update()
    {
        int h = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int v = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        Vector2Int moved = new Vector2Int(0, 0);
        if(h!=0)
        {
            moved.x = GetMoved(ref hCooldown, h);
        }
        else
        {
            hCooldown = 0;
        }

        if(v!=0)
        {
            moved.y = GetMoved(ref vCooldown, v);
        }
        else
        {
            vCooldown = 0;
        }

        if(moved!=Vector2Int.zero)
        Debug.Log(moved);
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Tecla esquerda da mouse pressionada");
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
