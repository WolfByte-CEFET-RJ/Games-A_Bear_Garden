using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D Rigid;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(moveH + moveV));
    }

    private void FixedUpdate() {
        Rigid.velocity = new Vector2(moveH, moveV);
    }
}
