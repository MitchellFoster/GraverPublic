using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public PlayerHealth health;

    public HealthBar Healthbar;
    public XPBar XPBar;
    public AudioSource levelupSound;

    int currentXP = 0;
    int nextLevelUp = 100;
    int remainingXP = 0;

    public void GainExperience(int amount)
    {
        currentXP += amount;
        XPBar.SetCurrentXP(currentXP);

        if (currentXP >= nextLevelUp)
        {
            remainingXP = currentXP - nextLevelUp;

            XPBar.SetCurrentXP(remainingXP);
            HealthUp();
        }
    }

    void HealthUp()
    {
        nextLevelUp += 100;
        health.health += 10;
        health.currentHealth = health.health;

        levelupSound.Play();

        Healthbar.SetMaxHealth(health.currentHealth);

        XPBar.SetXP(nextLevelUp);

        currentXP = remainingXP;
    }
}
