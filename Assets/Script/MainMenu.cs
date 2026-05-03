using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartLevel;
    public string LevelSelect;

    public void NewGame()
    {
        SceneManager.LoadScene(StartLevel);
    }

    public void LevelSelectMenu()
    {
        SceneManager.LoadScene(LevelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
