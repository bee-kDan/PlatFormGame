using UnityEngine;

public class Banana : MonoBehaviour
{
    public float speed;
    public Controller player;
    private Rigidbody2D rd;

    public int damageAmount;

    private bool hasHit = false;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Controller>();
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    void Update()
    {
        rd.linearVelocity = new Vector2(speed, rd.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return; // prevent duplicate processing

        if (other.CompareTag("Enemy"))
        {
            hasHit = true;
            // find the EnemyHealthManager on the enemy root (safer if enemy has child colliders)
            var enemyHealth = other.GetComponentInParent<EnemyHealthManager>();
            if (enemyHealth != null)
            {
                enemyHealth.giveDamage(damageAmount);
                Debug.Log("Banana hit enemy");
            }

            // immediately disable this collider so further trigger callbacks won't happen
            var col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
    }
}