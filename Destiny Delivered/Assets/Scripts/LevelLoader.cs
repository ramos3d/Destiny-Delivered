using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : LevelController
{
    public static int next_level;
    private int seconds = 2;

    // Start is called before the first frame update
    void Start()
    {
        next_level = LevelController.current_level; // This current_level comes already added to +1
        
        StartCoroutine(Load( next_level));
        Debug.Log("Scene LevelLoader says: next level will be --> " + next_level);
    }

     IEnumerator Load(int level_number)
    {
        yield return new WaitForSeconds(seconds); // Wait for x seconds;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
