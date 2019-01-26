using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int moveSpeed, jumpCount, jumpLimit;
    public float jumpForce;

    bool moving, airborne;
    
    Rigidbody2D playerBody;
    Animator animator;
    
 
    void Start () {      
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        animator.SetBool("Moving", moving); // Can this be moved to the Start() method? Worth testing later.
        animator.SetInteger("JumpCount", jumpCount);
        animator.SetBool("Airborne", airborne);
        HandleMovement();
	}

    void HandleMovement() {
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            if (!moving) moving = true;
        }

        // Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            if (!moving) moving = true;
        }

        else if (moving) moving = false;

        // Jump.
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < jumpLimit)
        {
            playerBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
            airborne = true;
            FindObjectOfType<AudioManager>().Play("Eagle"); // A simple test of Brackeys' Audio manager.
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            airborne = false;

            //FindObjectOfType<AudioManager>().Play("Demonic"); Just a test.
        }
    }
}