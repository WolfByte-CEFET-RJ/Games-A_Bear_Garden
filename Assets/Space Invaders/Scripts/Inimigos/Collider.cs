using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collider : MonoBehaviour, ICollider
{
   

    //Tiro -> destroi inimigo
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tiro")
             GetHit();
            //Destroy(this.gameObject);
    }

    public virtual void GetHit()
    {
        print("acertei inimigo");
        gameObject.SetActive(false);
    }

}
