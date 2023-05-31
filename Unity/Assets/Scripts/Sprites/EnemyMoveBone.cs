using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBone : MonoBehaviour
{
    public EnemyAI AI;
    public LayerMask playerLayer;

    public int _moveSpeed;
    public float _followRadius;

    bool facingRight = true;

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
        AI.setFollowRadius(_followRadius);
    }

    // Update is called once per frame
    void Update()
    {
        if (AI.checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (AI.checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    enemyAnim.SetBool("AttackA", true);
                }
                else
                {
                    this.transform.position += new Vector3(-AI.getMoveSpeed() * Time.deltaTime, 0f, 0f);
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
                }
                else
                {
                    this.transform.position += new Vector3(AI.getMoveSpeed() * Time.deltaTime, 0f, 0f);
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
}
