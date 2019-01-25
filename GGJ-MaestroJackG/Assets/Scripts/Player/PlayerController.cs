using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int moveSpeed, jumpCount, jumpLimit;
    public float jumpForce;
    
    Rigidbody2D playerBody;
 
    void Start () {      
        playerBody = GetComponent<Rigidbody2D>();      
    }
	
	void Update () {
        HandleMovement();
	}

    void HandleMovement() {               
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        // Jump.
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < jumpLimit)
        {
            playerBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }
}