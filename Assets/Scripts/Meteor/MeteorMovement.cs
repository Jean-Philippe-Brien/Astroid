using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    Rigidbody2D rbMeteor;
    Vector2 movement;
    float rotationSpeed;
    float speed;
    float timeWhithSameForce;
    void Start()
    {
        rbMeteor = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.5f, 5f);
        rotationSpeed = 1;
        timeWhithSameForce = 0;
    }

    void Update()
    {
        timeWhithSameForce -= Time.deltaTime;
        if(timeWhithSameForce <= 0)
        {
            speed = Random.Range(1f, 3f);
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeWhithSameForce = Random.Range(5f, 10f);
        }
        rbMeteor.velocity = Vector2.ClampMagnitude(rbMeteor.velocity, 2);
        rbMeteor.AddRelativeForce(movement * speed);
    }
}
