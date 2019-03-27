using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float accelerationTime = 0.3f;
    public float maxSpeed = 50f;
    private Vector2 movement;
    private float timeLeft;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
    }
}
