using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string mainMenu;
    public string levelSelect;
    public bool isPause;
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (isPause)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f; 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
    }

    public void Resume()
    {
        isPause = false;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
