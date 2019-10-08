using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 firstPosition;
    float timeBeforeDespawn;
    float speed;
    RaycastHit hitInfo;
    void Start()
    {
        timeBeforeDespawn = 1.3f;
        speed = 20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeBeforeDespawn -= Time.deltaTime;
        Vector3 posTop = transform.position + (transform.up * (GetComponent<SpriteRenderer>().bounds.size.y / 2));        
        Debug.DrawLine(posTop, posTop + (transform.up * Time.fixedDeltaTime * speed));
        RaycastHit2D hit = Physics2D.Raycast(posTop, transform.up, Time.fixedDeltaTime * speed, LayerMask.GetMask("Meteor","Wall"));
        if (hit)
            Debug.Log($"was hit: {hit.transform.name}");
        if (timeBeforeDespawn > 0)
            transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
        else
            GameObject.Destroy(gameObject);
        
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);
        }
    }
}
