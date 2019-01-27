using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FindObjectOfType<AudioManager>().Play("Turkish March"); // Play the main menu BGM again.
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            Application.Quit();
        }
	}
}