using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string firstLevel, levelSelect;

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    //public void Continue()
    //{
    //    SceneManager.LoadScene(levelSelect);
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
