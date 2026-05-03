using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool PlayerInZone;

    public string LevelToLoad;
    void Start()
    {
        PlayerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && PlayerInZone)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerInZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            PlayerInZone = false;
        }
    }

}
