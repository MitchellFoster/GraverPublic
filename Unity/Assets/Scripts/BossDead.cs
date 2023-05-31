using UnityEngine;

public class BossDead : MonoBehaviour
{
    public GameObject EndZone;

    public Health health;

    private void Update()
    {
        if(health.currentHealth <= 0)
        {
            OnDestroy();
        }
    }

    public void OnDestroy()
    {
        // Set the other object to false.
        EndZone.SetActive(false);
    }
}
