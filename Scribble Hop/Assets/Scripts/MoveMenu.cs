using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveMenu : MonoBehaviour
{
    public Player PlayerScript;
    public Moveables Movebl;

    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        PlayerScript.enabled = false;
        Movebl.enabled = false;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        PlayerScript.enabled = true;
        Movebl.enabled = true;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
