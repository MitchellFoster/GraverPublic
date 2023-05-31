using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject dustCloud;
    public AudioSource dusty;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            dusty.Play();
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);
        }
    }
}
