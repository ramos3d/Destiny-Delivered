using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : LevelController
{
    
    private bool _restart = false;
    [SerializeField] private GameObject UI_GAME_OVER;
    [SerializeField] private GameObject UI_MESSAGE;
    [SerializeField] private GameObject UI_RESULTS;

    // Start is called before the first frame update
    void Start()
    {
        print("DEBUG: Game Controller Has Started");
        this.LoadLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        // While is not Game Over
        
        if (Input.GetKeyDown(KeyCode.U)){
            UI_GAME_OVER.SetActive(!UI_GAME_OVER.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.I)){
            UI_MESSAGE.SetActive(!UI_MESSAGE.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.O)){
            UI_RESULTS.SetActive(!UI_RESULTS.activeSelf);
        }
    }

    void restartGame(){
        _restart = false;
        this.LoadLevel(1);
    }
    void GameOver(){
        
    }

}
