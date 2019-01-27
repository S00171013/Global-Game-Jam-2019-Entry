using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int moveSpeed, jumpCount, jumpLimit;
    public float jumpForce;
    public Text collectibleCountDisplay, overallScoreDisplay;
    public Transform respawnLocation;


    bool moving, airborne;
    public int collectiblesFound, fMembersFound;

    const int MEMBER_COUNT = 4;
    
    Rigidbody2D playerBody;
    Animator animator;
    
    void Start () {      
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();          
    }
	
	void Update () {       
        HandleMovement();
        HandleAnimations();
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
        }       
    }

    void HandleAnimations() {
        animator.SetBool("Moving", moving); 
        animator.SetInteger("JumpCount", jumpCount);
        animator.SetBool("Airborne", airborne);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            airborne = false;          
        }

        if (collision.gameObject.tag == "Hazard")
        {
            transform.position = respawnLocation.position;
            FindObjectOfType<AudioManager>().Play("Demonic");
        }

        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = respawnLocation.position;
            FindObjectOfType<AudioManager>().Play("Anger");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Orb")
        {
            Destroy(collision.gameObject); // Should probably move this to another class.
            collectiblesFound++;
            collectibleCountDisplay.text = collectiblesFound.ToString(); // Update the HUD. 
            //FindObjectOfType<AudioManager>().Play("Eagle"); // Play a sound effect to represent a new item collected.
        }

        if (collision.gameObject.tag == "House")
        {
            overallScoreDisplay.text = string.Format("Family found: "+fMembersFound+"/"+ MEMBER_COUNT);
            overallScoreDisplay.gameObject.SetActive(true);
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "House")
        {          
            overallScoreDisplay.gameObject.SetActive(false);
        }
    }
}