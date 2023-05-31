using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // First, add an AudioSource component to your game object that plays the audio.
    public AudioSource audioSource;
    public AudioSource bossMusic;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding game object has the player tag.
        if (collision.gameObject.tag == "Player")
        {
            // Stop the audio from playing.
            audioSource.Stop();
            bossMusic.Play();
        }
    }
}
