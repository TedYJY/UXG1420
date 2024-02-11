using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject levelLoader;
    public void Playgame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("DemoLevel");
        //GameObject.FindWithTag("MainMenu").GetComponent<LevelLoader>().LoadNextLevel();
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Quit gay");
        Application.Quit();
    }
}
