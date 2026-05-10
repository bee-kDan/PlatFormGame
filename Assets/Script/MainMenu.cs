using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartLevel;
    public string LevelSelect;
    public int playerLives;
    public int playerHealth;

    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentPlayerScore", 0);

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);

        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        SceneManager.LoadScene(StartLevel);
    }

    public void LevelSelectMenu()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentPlayerScore", 0);

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);

        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

        SceneManager.LoadScene(LevelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
