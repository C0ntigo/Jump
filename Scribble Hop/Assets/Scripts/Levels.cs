using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void Level()
    {
        SceneManager.LoadScene("Moveables");
    }
    public void Setting1()
    {
        SceneManager.LoadScene("Levels");
    }
}
