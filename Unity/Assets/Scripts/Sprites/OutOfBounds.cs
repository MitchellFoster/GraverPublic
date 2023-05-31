using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public PlayerHealth player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Die();
        }
    }
}
