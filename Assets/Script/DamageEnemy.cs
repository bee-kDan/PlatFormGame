using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damageToGive;

    public float bounceForce;

    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, bounceForce);
        }
    }
}
