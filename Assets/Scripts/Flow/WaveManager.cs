using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : IManager
{
    #region singleton
    private static WaveManager instance;
    private WaveManager() { }
    public static WaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WaveManager();
            }
            return instance;
        }
    }
    #endregion

    int waveCount;
    int meteorCount;
    int waveSize;
    float distanceSpawn;
    float distanceTeleport;
    public bool waveStart;
    Transform playerPos;
    GameObject asteroid;

    public void FirstInitialization()
    {
        waveStart = false;
        waveSize = 50;
        waveCount = 1;
        distanceSpawn = 50;
        distanceTeleport = 60;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        GameLinks.gl.counter.GetComponent<Counter>().SetCoolDown(3);
        asteroid = Resources.Load<GameObject>("Prefabs/Asteroid");
    }

    public void PhysicsRefresh()
    {
        
    }

    public void Refresh()
    {
        if(waveStart)
        {
            waveStart = false;
            SpawnAsteroids();
        }
    }

    public void SecondInitialization()
    {
        
    }
    void SpawnAsteroids()
    {
        while (waveSize > 0)
        {

            waveSize -= 10;
            GameObject newAsteroid = GameObject.Instantiate(asteroid);
            //newAsteroid.GetComponent<Asteroid>().size = Random.Range(50f, 100f);
            Debug.Log("bob");
        }
    }

}
