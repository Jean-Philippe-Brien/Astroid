using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    private void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
        GameFlow.Instance.FirstInitialization();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameFlow.Instance.SecondInitialization();
    }

    // Update is called once per frame
    void Update()
    {
        GameFlow.Instance.Refresh();
    }
    private void FixedUpdate()
    {
        GameFlow.Instance.PhysicsRefresh();
    }
}
