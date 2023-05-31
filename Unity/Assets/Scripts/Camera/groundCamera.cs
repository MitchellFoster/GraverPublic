using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCamera : MonoBehaviour
{
    public GameObject foreground;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreground.transform.position = new Vector3(transform.position.x, 7, transform.position.z);
        }
    }
}
