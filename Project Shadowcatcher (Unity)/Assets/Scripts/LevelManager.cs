using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextLevel()
    {
        Debug.Log("yes");

        int currentSceneIndex = 1;
        SceneManager.LoadScene(currentSceneIndex++);
        Debug.Log("Loaded currentSceneIndex" + currentSceneIndex);
    }
}
