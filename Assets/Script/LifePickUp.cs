using UnityEngine;

public class LifePickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private LifeManager lifeManager;
    void Start()
    {
        lifeManager = FindAnyObjectByType<LifeManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            lifeManager.ExtraLife();
            Destroy(gameObject);
        }
    }
}
