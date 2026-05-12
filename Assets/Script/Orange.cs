using UnityEngine;

public class Orange : MonoBehaviour
{
    public float speed;
    public int damageAmount;

    private int PlayerHealth;

    private Rigidbody2D rb;
    private Controller player;

    private bool hasHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = FindAnyObjectByType<Controller>();

        // kiểm tra player tồn tại
        if (player != null)
        {
            // nếu player ở bên trái -> đạn bay sang trái
            if (player.transform.position.x < transform.position.x)
            {
                speed = -Mathf.Abs(speed);
            }
            else
            {
                speed = Mathf.Abs(speed);
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        // dùng CompareTag tốt hơn so với so sánh name
        if (other.CompareTag("Player"))
        {
            hasHit = true;

            PlayerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

            if (PlayerHealth != null)
            {
                HealthManager.GiveDamage(damageAmount);
                Debug.Log("Enemy shoot player");
            }

            // tắt collider tránh trigger nhiều lần
            Collider2D col = GetComponent<Collider2D>();

            if (col != null)
            {
                col.enabled = false;
            }

            Destroy(gameObject);
        }
    }
}