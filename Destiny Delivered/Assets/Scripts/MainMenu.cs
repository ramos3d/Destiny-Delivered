using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        Debug.Log("game started");
       // SceneManager.LoadScene("Game");                 // Load the Scene Game.
        SceneManager.LoadScene("AI NPC");
    }

    public void QuitGame(){
        Application.Quit();
    }

    private void Update() {
        if(Input.GetKeyDown("escape")){
            Application. Quit();
        }
    }    
}
