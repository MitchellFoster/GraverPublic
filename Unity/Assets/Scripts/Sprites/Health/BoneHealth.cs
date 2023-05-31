using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneHealth : MonoBehaviour
{
    [SerializeField]
    public EnemyScriptable enemyScriptable;
    public EnemyMoveBone enemyAnim;

    [SerializeField]
    public LevelUp LevelUp;

    int currentHealth;

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
        enemyAnim.enemyAnim.SetBool("Walking", false);
        enemyAnim.enemyAnim.SetBool("AttackA", false);
        enemyAnim.enemyAnim.SetBool("Hit", true);
        Invoke("SetBoolBack", 1);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
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
