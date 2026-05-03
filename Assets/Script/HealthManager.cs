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

    void Start()
    {
        text = GetComponent<TMP_Text>();
        PlayerHealth = PlayerMaxHealth;

        levelManager = FindAnyObjectByType<LevelManager>();
        isDead = false;
    }
    private void Update()
    {
        if (PlayerHealth <= 0 && !isDead)
        {   
            PlayerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }
        text.text = "" + PlayerHealth;
    }

    public static void GiveDamage(int damageAmount)
    {
        PlayerHealth -= damageAmount;
    }   
    public void FullHealth()
    {
        PlayerHealth = PlayerMaxHealth;
    }
}
    