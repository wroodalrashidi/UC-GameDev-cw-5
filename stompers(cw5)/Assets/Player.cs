using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jump;
    public bool canJump = false;
    public Animator animator;

void Start()
    {
        speed = 5;
        jump = 5;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

private void OnCollisionEnter2D(Collision2D collision) 
    {
    
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
            {
                canJump = true;
                animator.SetBool("jump", false);
            }


}

private void Update() {
        Vector2 temp = rb.velocity;

        if (canJump && Input.GetKey(KeyCode.Space)) 
        {
            temp.y = jump;
            canJump = false;
            
        }
        
            temp.x = (Input.GetAxis("Horizontal") * speed);
            rb.velocity = temp;
            
    

    }

}

