using UnityEngine;

public class ShootAtPlayerInRange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float playerRange;

    public GameObject enemyStar;

    public Controller player;

    public Transform launchPoint;

    public float shootCounter;
    public float waitBetweenShots;
    void Start()
    {
        player = FindAnyObjectByType<Controller>();

        shootCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(
            new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z),
            new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z)
        );

        shootCounter -= Time.deltaTime;

        // enemy quay trái
        if (
            transform.localScale.x < 0 &&
            player.transform.position.x < transform.position.x &&
            player.transform.position.x > transform.position.x - playerRange &&
            shootCounter < 0
        )
        {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);

            shootCounter = waitBetweenShots;
        }

        // enemy quay phải
        if (
            transform.localScale.x > 0 &&
            player.transform.position.x > transform.position.x &&
            player.transform.position.x < transform.position.x + playerRange &&
            shootCounter < 0
        )
        {
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);

            shootCounter = waitBetweenShots;
        }
    }
}
