using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenuController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Stop("Turkish March"); // Stop the main menu BGM.
            FindObjectOfType<AudioManager>().Play("Polovtsian Dances"); 
            SceneManager.LoadScene("sc_level_test");
        }
    }
}