using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyMember : MonoBehaviour
{
    public Text message;
    public string memberName;

    PlayerController playerRef;
    TimeManager tm;
    int collectiblesGathered;
    bool found;

    void Start()
    {        
        playerRef = GameObject.Find("player_test").GetComponent<PlayerController>(); // Get a reference to the player.

        found = false;
    }

    void Update() {
        if(found)
        {            
            message.text = string.Format("You found your "+ memberName + "!");
            message.gameObject.SetActive(true);

            playerRef.fMembersFound++;
            Destroy(this.gameObject);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            found = true;
            //playerRef.fMembersFound++; // Add to the player's member count.

            //Destroy(this.gameObject);
        }
    }
}
