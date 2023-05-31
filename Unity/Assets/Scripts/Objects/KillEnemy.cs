using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            Destroy(other.gameObject);
        }
    }
}
