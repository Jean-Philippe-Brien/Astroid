﻿using System.Collections;
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
    public bool waveStart;
    Transform playerPos;
    GameObject asteroid;
    public List<Asteroid> asteroids = new List<Asteroid>();

    public void FirstInitialization()
    {
        
        
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
            waveSize = waveSize * (1.3f + waveCount * Random.Range(0.05f, 0.15f));
            Debug.Log("wave " + waveCount + " begin size " + waveSize);
            asteroids.Clear();
            PlayerManager.Instance.setCanFire();
            UiManager.Instance.SetWaveCounter(waveCount);
            UiManager.Instance.SetCoolDown(5);
        }
    }

    public void SecondInitialization()
    {
        waveStart = false;
        waveSize = 5000;
        waveCount = 1;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        UiManager.Instance.SetCoolDown(3);
        asteroid = Resources.Load<GameObject>("Prefabs/Asteroid");
    }
    void SpawnAsteroids()
    {
        numAsteroid = 0;
        while (waveSizeCounter > 0)
        {

            waveSizeCounter -= Random.Range(4,8);
            CoroutineSpawnAsteroid.SpawnAsteroid(asteroid, numAsteroid);
            numAsteroid++;
        }
        UiManager.Instance.SetAsteroidCounter(numAsteroid);
    }
    
}
