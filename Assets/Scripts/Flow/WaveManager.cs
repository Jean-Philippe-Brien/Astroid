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
    float waveSize;
    float waveSizeCounter;
    public int numAsteroid = 0;
    bool waveOnPlay = false;
    float distanceSpawn;
    float distanceTeleport;
    public bool waveStart;
    Transform playerPos;
    GameObject asteroid;
    public List<Asteroid> asteroids = new List<Asteroid>();

    public void FirstInitialization()
    {
        
        waveStart = false;
        waveSize = 50;
        waveCount = 1;
        distanceSpawn = 50;
        distanceTeleport = 60;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        UiManager.Instance.SetCoolDown(3);
        asteroid = Resources.Load<GameObject>("Prefabs/Asteroid");
    }

    public void PhysicsRefresh()
    {
        
    }

    public void Refresh()
    {
        if(waveStart)
        {
            waveSizeCounter = waveSize;
            waveStart = false;
            waveOnPlay = true;
            SpawnAsteroids();
        }
        foreach(Asteroid instanceAsteroid in asteroids)
        {
            if(instanceAsteroid != null)
                instanceAsteroid.verifyDistanceToPlayer(playerPos.position);
        }
        if(numAsteroid == 0 && waveOnPlay)
        {
            waveOnPlay = false;
            waveCount++;
            waveSize = (waveSize * 1.3f) + (waveCount * 0.05f);
            Debug.Log("wave " + waveCount + " begin size " + waveSize);
            asteroids.Clear();
            UiManager.Instance.SetWaveCounter(waveCount);
            UiManager.Instance.SetCoolDown(5);
        }
    }

    public void SecondInitialization()
    {
        
    }
    void SpawnAsteroids()
    {
        numAsteroid = 0;
        while (waveSizeCounter > 0)
        {

            waveSizeCounter -= 7;
            CoroutineSpawnAsteroid.SpawnAsteroid(asteroid, numAsteroid);
            numAsteroid++;
        }
        UiManager.Instance.SetAsteroidCounter(numAsteroid);
    }
    
}
