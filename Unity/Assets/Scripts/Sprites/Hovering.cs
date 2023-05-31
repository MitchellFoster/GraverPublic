using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float horizontalSpeed;
    [Range(0, 5)]
    public float verticalSpeed;
    [Range(0, 2)]
    public float amplitude;

    private Vector3 originalPos;
    private Vector3 tempPosition;

    void Start()
    {
        tempPosition = originalPos = transform.position;
    }

    void FixedUpdate()
    {
        tempPosition = originalPos;
        tempPosition.x += horizontalSpeed * Time.fixedDeltaTime;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}
