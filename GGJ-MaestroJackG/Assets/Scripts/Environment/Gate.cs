using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour {
    public int collectibleRequirement;
    public Text requirementDisplay;

    PlayerController playerRef;
    int collectiblesGathered;
    TimeManager tm;


    void Start () {
        requirementDisplay.text = string.Format("X "+ collectibleRequirement);

        playerRef = GameObject.Find("player_test").GetComponent<PlayerController>(); // Get a reference to the player.
    }
			
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {           
            collectiblesGathered = playerRef.collectiblesFound; // Get the player's current collectible count.

            if(collectiblesGathered >= collectibleRequirement)
            {
                Destroy(this.gameObject);
            }
        }
    }
}