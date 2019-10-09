using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D info = Physics2D.OverlapBox(transform.position, transform.GetComponent<SpriteRenderer>().bounds.size, 0, LayerMask.NameToLayer("Wall"));
        if(info != null)
        {
            Debug.Log(info.transform.name);
        }
    }
}
