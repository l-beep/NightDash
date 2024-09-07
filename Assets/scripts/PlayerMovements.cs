using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 7;
    private Rigidbody2D rb;
    public float Acceleration;
    public float JumpForce;
    private bool isGrounded = true;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed += Acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f)* moveSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Space)&& isGrounded)
        {

            jump();
            animator.SetBool("jump", true);
            isGrounded = false;
        }
    }

    void jump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = JumpForce;
        rb.velocity = velocity;
       // Debug.Log("player jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
           // Debug.Log("IsGrounded");
            isGrounded = true;
            animator.SetBool("jump", false);
        }
    }
}
