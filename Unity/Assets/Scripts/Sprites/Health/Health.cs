using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public EnemyScriptable enemyScriptable;
    public EnemyMove enemyAnim;

    [SerializeField]
    public LevelUp LevelUp;

    public int currentHealth;

    public AudioSource sourceAudio;
    public float volume = 1;
    public AudioSource deathSound;

    void Start()
    {
        currentHealth = enemyScriptable.health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        sourceAudio.Play();
        if(enemyAnim != null)
        {
            enemyAnim.enemyAnim.SetBool("Walking", false);
            enemyAnim.enemyAnim.SetBool("AttackA", false);
            enemyAnim.enemyAnim.SetBool("Hit", true);
            Invoke("SetBoolBack", 1);

            // Get the Rigidbody component of the enemy
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            // Apply a force to the enemy's Rigidbody in the opposite direction of the attack
            rb.AddForce(new Vector2(-2f, 1f) * 10f, ForceMode2D.Impulse);
        }
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died");
        deathSound.Play();
        Destroy(gameObject);
        LevelUp.GainExperience(enemyScriptable.experience);
    }

    private void SetBoolBack()
    {
        enemyAnim.enemyAnim.SetBool("Hit", false);
    }
}
