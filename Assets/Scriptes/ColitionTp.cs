using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColitionTp : MonoBehaviour
{
    public GameObject destination;
    public Vector2 xYMax;
    public Vector2 xYMini;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float time = Time.time - startTime;
        if (time > 20) {
            destination.transform.position = new Vector3(Random.Range(xYMax.x, xYMini.x), Random.Range(xYMax.y, xYMini.y), 0);
            startTime = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destination.transform.position = new Vector3(Random.Range(xYMax.x, xYMini.x), Random.Range(xYMax.y, xYMini.y), 0);
        startTime = Time.time;
    }
}
