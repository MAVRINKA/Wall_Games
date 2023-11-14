using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1000;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(50 * Time.deltaTime * speed, 50 * Time.deltaTime * speed));
    }
}
