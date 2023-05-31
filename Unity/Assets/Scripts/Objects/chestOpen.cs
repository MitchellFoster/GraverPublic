using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestOpen : MonoBehaviour
{
    [SerializeField]
    public LevelUp LevelUp;

    public Animator animController;
    public AudioSource opening;

    bool isOpen = false;
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isOpen == false)
        {
            animController.SetBool("isOpen", true);
            opening.Play();
            LevelUp.GainExperience(100);
            isOpen = true;
        }
    }
}
