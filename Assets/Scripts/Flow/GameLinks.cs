using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLinks : MonoBehaviour
{
    public static GameLinks gl;

    public Transform player;

    public Text counter;

    public GameObject explosion;
    private void Awake()
    {
        explosion = Resources.Load<GameObject>("Prefabs/Explosion");
    }
}
