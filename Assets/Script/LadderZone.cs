using UnityEngine;

public class LadderZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Controller thePlayer;
    void Start()
    {
        thePlayer = FindAnyObjectByType<Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
             thePlayer.onLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }


    // Update is called once per frame
}
