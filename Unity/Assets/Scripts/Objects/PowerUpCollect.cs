using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollect : MonoBehaviour
{
    public CharacterController2D character;
    public GameObject PowerUp;

    public AudioSource sourceAudio;
    public float volume = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            character.canCrouch = true;
            PowerUp.SetActive(false);
            sourceAudio.Play();
        }
    }
}
