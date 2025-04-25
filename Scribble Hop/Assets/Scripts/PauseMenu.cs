using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public Player PlayerScript;

    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        PlayerScript.enabled = false;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        PlayerScript.enabled = true;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
