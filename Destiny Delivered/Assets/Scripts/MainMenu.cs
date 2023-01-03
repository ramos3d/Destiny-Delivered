using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Game");                 // Load the Scene Game.
       // Application.LoadLevel("Game");                // This is obsolete
    }


    public void QuitGame(){
        Application.Quit();
    }
}
