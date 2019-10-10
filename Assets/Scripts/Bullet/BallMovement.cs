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

        timeBeforeDespawn = 1.8f;
        speed = 40;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckOutBounds();
        timeBeforeDespawn -= Time.deltaTime;
        Vector3 posTop = transform.position + (transform.up * (GetComponent<SpriteRenderer>().bounds.size.y / 2));        
        RaycastHit2D hit = Physics2D.Raycast(posTop, transform.up, Time.fixedDeltaTime * speed, LayerMask.GetMask("Meteor"));
        if (timeBeforeDespawn > 0)
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
        }
        else
            GameObject.Destroy(gameObject);
        
        if (hit.collider != null)
        {
           // Debug.Log(hit.transform.name);
        }
        
    }
    void CheckOutBounds()
    {
        Vector2 newPos;
        float distance = Vector2.Distance(GameLinks.gl.player.position, transform.position);
        Debug.Log(distance);
        if(distance >= 18)
        {

            newPos = RotatePoint(GameLinks.gl.player.transform.position.x, GameLinks.gl.player.transform.position.y, 180, transform.position);
            transform.localPosition = new Vector3(newPos.x, newPos.y, 0);
        }
    }
    public static Vector2 RotatePoint(float cx, float cy, float DegAngle, Vector2 p)
    {
        float angle = (DegAngle) * Mathf.PI / 180;
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        p.x -= cx;
        p.y -= cy;
        float xnew = p.x * c - p.y * s;
        float ynew = p.x * s + p.y * c;
        p.x = xnew + cx;
        p.y = ynew + cy;
        return p;
    }
}
