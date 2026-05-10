using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float countingTime;
    public float startingTime;

    public TMP_Text text;

    private PauseMenu pauseMenu;

    public GameObject gameOverScene;

    public Controller player;

    private HealthManager healthManager;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        countingTime = startingTime;

        pauseMenu = FindAnyObjectByType<PauseMenu>();

        healthManager = FindAnyObjectByType<HealthManager>();

        player = FindAnyObjectByType<Controller>();
    }

    void Update()
    {
        if (pauseMenu != null && pauseMenu.isPause)
        {
            return;
        }

        countingTime -= Time.deltaTime;

        if (countingTime <= 0)
        {
            //gameOverScene.SetActive(true);
            //player.gameObject.SetActive(false);
            healthManager.KillPlayer();
        }

        text.text = "" + Mathf.RoundToInt(countingTime);
    }
    public void ResetTime()
    {
        countingTime = startingTime;
    }
}