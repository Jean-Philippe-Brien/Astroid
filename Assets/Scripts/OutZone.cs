using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform oppositeOutZone;
    float offset;
    bool tpActive;
    void Start()
    {
        tpActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WallHit(Transform t)
    {
        if (transform.tag == "WallY")
        {
            offset = collision.bounds.size.y;
            collision.transform.position = new Vector3(collision.transform.position.x, oppositeOutZone.position.y + ((oppositeOutZone.position.y > 0) ? -offset : offset), 0);
        }
        else
        {
            offset = collision.bounds.size.x;
            collision.transform.position = new Vector3(oppositeOutZone.position.x + ((oppositeOutZone.position.x > 0) ? -offset : offset), collision.transform.position.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WallHit(collision.transform);
    }
}
