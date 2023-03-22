using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : LevelController
{
    private int seconds = 2;
    void Start()
    {
        StartCoroutine(Load());
    }

     IEnumerator Load()
    {
        yield return new WaitForSeconds(seconds); 
        if (GameManager.GetLevel() >= LevelController.total_levels)
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("AI NPC", LoadSceneMode.Single);
        }
    }
}