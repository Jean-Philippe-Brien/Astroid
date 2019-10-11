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



    public void FirstInitialization()
    {
    }

    public void PhysicsRefresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
    void SpawnAsteroids()
    {

    }

}
