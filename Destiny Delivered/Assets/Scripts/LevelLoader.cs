using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int current_level;
    private int seconds = 3;

    // Start is called before the first frame update
    void Start()
    {
        current_level = LevelController.current_level; // This current_level comes already added to +1
        StartCoroutine(Load( current_level));
        Debug.Log("Scene LevelLoader says: next level will be --> " + current_level);
    }

     IEnumerator Load(int level_number)
    {
        yield return new WaitForSeconds(seconds); // Wait for x seconds;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("AI NPC", LoadSceneMode.Single); 
        //AsyncOperation asyncOperation = SceneManager.LoadScene("AI NPC");
        asyncOperation.allowSceneActivation = false; // Prevents the scene from activating immediately.

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true; // Activate scene when it is ready
            }

            yield return null;
        }
    }
}
