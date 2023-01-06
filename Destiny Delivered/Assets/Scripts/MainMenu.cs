using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start the game
    public void StartGame(){
        Debug.Log("game started");
        SceneManager.LoadScene("Game");                 // Load the Scene Game.
    }

    // Quit the game
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Closing");
    }

    private void Update() {
        if(Input.GetKeyDown("escape")){
            Application. Quit();
            Debug.Log("Closing");

        }

        
    }    
}
