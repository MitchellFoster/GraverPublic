using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollider : MonoBehaviour
{
    public GameObject background;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("changeBackground");
        }
    }

    IEnumerator changeBackground()
    {
        yield return new WaitForSeconds(1/2);
        background.transform.position = new Vector3(transform.position.x, -7, transform.position.z);
    }
}
