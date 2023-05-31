using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public EnemyAI AI;
    public LayerMask playerLayer;
    public AudioSource sourceAudio;
    public int attackDamage = 30;
    public CircleCollider2D attackRange;

    public int _moveSpeed;
    public float _attackRadius;
    public float _followRadius;

    bool facingRight = true;
    bool busy = false;

    public RaycastHit2D hit;

    [SerializeField] Transform playerTransform;
    [SerializeField] public Animator enemyAnim;

    void Start()
    {
        //get the player transform   
        playerTransform = FindObjectOfType<CharacterController2D>().GetComponent<Transform>();

        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();

        //set the variables
        AI.setMoveSpeed(_moveSpeed);
        AI.setAttackRadius(_attackRadius);
        AI.setFollowRadius(_followRadius);
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, AI.getFollowRadius(), playerLayer);

        if (AI.checkFollowRadius(playerTransform.position.x, transform.position.x) && hit.collider != null)
        {
            

            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (AI.checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAnim.SetBool("AttackA", true);

                    if (!busy)
                    {
                        busy = true;
                        StartCoroutine(inRange());
                    }
                }
                else
                {
                    // Move the enemy towards the player
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, AI.getMoveSpeed() * Time.deltaTime);
                    enemyAnim.SetBool("AttackA", false);
                    enemyAnim.SetBool("Walking", true);

                    if (facingRight == false)
                    {
                        Flip();
                        facingRight = true;
                    }
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.x > transform.position.x)
            {
                if (AI.checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAnim.SetBool("AttackA", true);

                    if (!busy)
                    {
                        busy = true;
                        StartCoroutine(inRange());
                    }
                }
                else
                {
                    // Move the enemy towards the player
                    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, AI.getMoveSpeed() * Time.deltaTime);
                    enemyAnim.SetBool("AttackA", false);
                    enemyAnim.SetBool("Walking", true);

                    if (facingRight == true)
                    {
                        Flip();
                        facingRight = false;
                    }
                }
            }
        }
        else
        {
            enemyAnim.SetBool("Walking", false);
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    IEnumerator inRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackRange.bounds.center, attackRange.radius);

        foreach (Collider2D collider in colliders)
        {
            sourceAudio.Play();
            new WaitForSeconds(.5f);
            // If the collider is the player
            if (collider.tag == "Player")
            {
                StartCoroutine(dealDmg(1f));
                collider.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(1f);
        busy = false;
    }

    IEnumerator dealDmg(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
