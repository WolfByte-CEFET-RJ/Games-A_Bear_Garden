using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFatherMove : MonoBehaviour
{
    private bool isVertical;
    [SerializeField] private float speedHor;
    private float speedVert;
    void Start()
    {
        speedVert = speedHor;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isVertical)
        {
            transform.Translate(Vector3.right * speedHor * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speedVert * Time.deltaTime);
        }
    }

    public IEnumerator ChangeSize()
    {
        isVertical = true;
        yield return new WaitForSeconds(0.5f);
        speedHor = -speedHor;
        isVertical = false;
    }
}
