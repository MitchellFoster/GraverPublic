using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger area is the player.
        if (other.gameObject.tag == "Player")
        {
            // If the object that entered the trigger area is the player, move the object to scene 0.
            SceneManager.LoadScene(0);
        }
    }
}
