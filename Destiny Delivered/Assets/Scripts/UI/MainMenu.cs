using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(){
        GameManager.SetLevel(1);
       // SceneManager.LoadScene("AI NPC");
        SceneManager.LoadScene("Game");                 // Load the Scene Game.
    }

    public void QuitGame(){
        Application.Quit();
    }

    private void Update() {
        if(Input.GetKeyDown("escape")){
            Application.Quit();
        }
    }    
}
