using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //public int staringLives;

    private int liveCounter;

    public GameObject gameOverScene;

    public Controller player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    TMP_Text theText;

    public string mainMenu;

    public float waitAfterGameOver;
    void Start()
    {
        theText = GetComponent<TMP_Text>();

        liveCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        player = FindAnyObjectByType<Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        if (liveCounter <= 0)
        {
            gameOverScene.SetActive(true);
            player.gameObject.SetActive(false); 
        }
        theText.text = "x " + liveCounter;

        if (gameOverScene.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }
        if (waitAfterGameOver < 0)
        {
            SceneManager.LoadScene(mainMenu);
        }
    }
    public void ExtraLife()
    {
        liveCounter +=1;
        PlayerPrefs.SetInt("PlayerCurrentLives", liveCounter);
    }
    public void MinusLife()
    {
        liveCounter -=1;
        PlayerPrefs.SetInt("PlayerCurrentLives", liveCounter);
    }
}
