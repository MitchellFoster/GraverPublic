using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public HealthBar Healthbar;

    public int currentHealth;
    public int health;

    [SerializeField]
    private float invincibilityDeltaTime;

    [SerializeField]
    private float invincibilityDurationSeconds = 1.25f;

    private bool isInvincible = false;

    public AudioSource sourceAudio;
    public float volume = 1;

    private Rigidbody2D rb;

    public Color flashColor;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = health;

        // Get the Rigidbody component of the player character
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        spriteRenderer.color = flashColor;

        sourceAudio.Play();

        // Start the knockback Coroutine, passing in the knockback force as an argument
        StartCoroutine(Knockback(new Vector2(-1f, 0.25f) * 10f));

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(BecomeTemporarilyInvincible());

        Healthbar.SetHealth(currentHealth);
    }
    public void Die()
    {
        Debug.Log("Player died");
        StartCoroutine(endGame());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            TakeDamage(20);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            TakeDamage(20);
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        isInvincible = false;
        spriteRenderer.color = originalColor;
    }

    public IEnumerator Knockback(Vector2 knockbackForce)
    {
        // Apply the knockback force to the player
        rb.AddForce(knockbackForce, ForceMode2D.Impulse);

        // Wait for half a second
        yield return new WaitForSeconds(0.5f);
    }
    public IEnumerator endGame()
    {
        animator.Play("Death");
        yield return new WaitForSeconds(1f);
        Restart();
    }
}
