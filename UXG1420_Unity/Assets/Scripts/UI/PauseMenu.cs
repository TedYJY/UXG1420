using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject resumeButton;
    // Update is called once per frame

    void Start()
    {
        Time.timeScale = 1.0f;
    }
    
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("shit worksRESUME");
                GameResume();
            }
            else
            {
                Debug.Log("shit worksPAUSE");
                PauseGame();
                
            }
        }//*/
    }

    //

    public void GameResume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        Debug.Log("PAUSE");
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }//*/


    /*void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }//*/

    public void LoadMenu()
    {
        Debug.Log("Load");
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Debug.Log("qUIT");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("restart");
        
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
