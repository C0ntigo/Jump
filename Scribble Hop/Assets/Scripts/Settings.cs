using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject settingsMenu;
    public void Home()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void GetOut()
    {
        settingsMenu.SetActive(false);
        start.SetActive(true);
    }
    public void Setting() 
    {
        settingsMenu.SetActive(true);
        start.SetActive(false);
    }
}
