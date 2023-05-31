using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private ParticleSystem damageParticles;

    private ParticleSystem damageParticlesInstance;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0;

    public AudioSource attackPlayer;
    private Vector2 attackDirection;

    /// <summary>
    /// fixes the problem with animation getting stuck after going crouch
    /// </summary>
    private void Awake()
    {
        GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack(attackDirection);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack(Vector2 attackDirection)
    {
        animator.SetTrigger("Attack");

        attackPlayer.Play();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            SpawnDamageParticles(attackDirection);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void SpawnDamageParticles(Vector2 attackDirection)
    {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);

        damageParticlesInstance = Instantiate(damageParticles, transform.position, spawnRotation);
    }
}
