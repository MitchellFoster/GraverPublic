using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuParallax : MonoBehaviour
{
    public float scrollSpeed = -5f;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 1920);
        transform.position = startPos + Vector2.right * newPos;
    }
}
