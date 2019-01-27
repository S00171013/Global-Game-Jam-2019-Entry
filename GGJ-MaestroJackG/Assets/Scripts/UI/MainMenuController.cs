﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject quitDialogBox;

    public enum menuState
    {
        MAIN,
        QUIT
    }

    public menuState phase;

	void Start () {
        phase = menuState.MAIN;
        FindObjectOfType<AudioManager>().Play("Turkish March"); // Play the main menu BGM.
    }

    public void OpenQuitDialog() {
        if (phase == menuState.MAIN) {
            phase = menuState.QUIT;
            quitDialogBox.SetActive(true);         
        }
    }

    public void StartGame() {
        if (phase == menuState.MAIN)
        {
            FindObjectOfType<AudioManager>().Stop("Turkish March"); // Stop the main menu BGM.
            FindObjectOfType<AudioManager>().Play("Polovtsian Dances"); // Play the main menu BGM.
            SceneManager.LoadScene("sc_level_test");
        }
    }    

    public void CloseQuitDialog() {
        if (phase == menuState.QUIT) {
            phase = menuState.MAIN;
            quitDialogBox.SetActive(false);          
        }
    }

    public void QuitGame() {
        if (phase == menuState.QUIT) {        
            Application.Quit(); // Close the game.
        }
    }
}