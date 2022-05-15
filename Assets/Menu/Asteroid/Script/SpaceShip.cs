using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Rigidbody2D Rigid;
    public float movementSpeed = 5f;
    public float rotationSpeed = 160f;  
    float rotation;

    public GameObject bulletPrefab;
    public Restarter restarter;

    void Start()
    {
        
    }


    void FixedUpdate() {

        float v = Input.GetAxisRaw("Vertical");
        Rigid.AddForce(((Vector2)transform.up * v * movementSpeed) - Rigid.velocity, ForceMode2D.Force);
    }
    
    void Update() {
        
        float rotationDir = 0f;

        if(Input.GetKey(KeyCode.A)) {
            rotationDir = 1f;        
        } else {
            if(Input.GetKey(KeyCode.D)) {
                rotationDir = -1f;
            }
        }

        rotation += rotationDir * Time.smoothDeltaTime * rotationSpeed;
        transform.localEulerAngles = new Vector3(0f,0f,rotation);

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            restarter.Restart();
            gameObject.SetActive(false);
        }
    }
}
