using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Rigidbody2D Rigid;
    public float movementSpeed = 5f;
    public float rotationSpeed = 160f;  
    float rotation;
    float rotationDir;
    Vector2 direction;

    void Start() {
        rotationDir = Random.value > 0.5f ? -1f : 1f;
        direction = (Vector3.zero - transform.position).normalized;
    }

    void FixedUpdate() {
        Rigid.velocity = movementSpeed * direction;
    }

    void Update() {
        rotation += rotationDir * Time.smoothDeltaTime * rotationSpeed;
    }
}
