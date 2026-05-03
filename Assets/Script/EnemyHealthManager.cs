using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int enemyHealth;
    
    public GameObject deathParticle;

    public int pointsOnDeath;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            ScoreManager.AddPoints(pointsOnDeath);
            GameObject death = Instantiate(deathParticle, transform.position, transform.rotation);
            //Chạy particle
            death.GetComponent<ParticleSystem>().Play();
            Destroy(death, 2f);
            Destroy(gameObject);
        }
    }
    public void giveDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        Debug.Log("Enemy health: " + enemyHealth);
    }
}
