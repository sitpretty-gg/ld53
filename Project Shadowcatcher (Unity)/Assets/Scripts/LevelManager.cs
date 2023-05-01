using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentSceneIndex = 0;
    public static LevelManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (instance = null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void NextLevel()
    {
        Debug.Log("Loading... " + currentSceneIndex++);
        SceneManager.LoadScene(currentSceneIndex++);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelComplete()
    {
        SceneManager.LoadScene(3);
    }
}
