using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int PlayerMaxHealth; 
    public static int PlayerHealth;
    public bool isDead;

    private LevelManager levelManager;
    TMP_Text text;

    private LifeManager lifeManager;
    private TimeManager timeSystem;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        //PlayerHealth = PlayerMaxHealth;
        PlayerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

        timeSystem = FindAnyObjectByType<TimeManager>();

        levelManager = FindAnyObjectByType<LevelManager>(); 

        lifeManager = FindAnyObjectByType<LifeManager>();

        isDead = false;
    }
    private void Update()
    {
        if (PlayerHealth <= 0 && !isDead)
        {   
            PlayerHealth = 0;
            levelManager.RespawnPlayer();
            lifeManager.MinusLife();
            isDead = true;
            timeSystem.ResetTime();
        }
        text.text = "" + PlayerHealth;
    }

    public static void GiveDamage(int damageAmount)
    {
        PlayerHealth -= damageAmount;
        PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerHealth);
    }
    public void GiveDamageFromBullet(int damageAmount)
    {
        PlayerHealth -= damageAmount;
        PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerHealth);
    }
    public void FullHealth()
    {
        PlayerHealth = PlayerMaxHealth;
        PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerHealth);
    }
    public void KillPlayer()
    {
        PlayerHealth = 0;
        
    }
}
    