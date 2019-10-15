using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : IManager
{
    #region singleton
    private static UiManager instance;
    private UiManager() { }
    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UiManager();
            }
            return instance;
        }
    }
    #endregion

    public Counter counterField;
    public Text waveCounter;
    public Text asteroidCounter;
    public Text liveCounter;
    public GameObject gameOverPanel;
    public void FirstInitialization()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("GameOver");
        gameOverPanel.SetActive(false);

    }
    public void SetCoolDown(int coolDown)
    {
        counterField.SetCoolDown(coolDown, 0);
    }
    public void SetCoolDownRespawn(int coolDown)
    {
        counterField.SetCoolDown(coolDown, 1);
    }
    public void SetWaveCounter(int wave)
    {
        waveCounter.text = "wave \n" + wave;
    }
    public void SetLiveCounter(int live)
    {
        liveCounter.text = "Lives: " + live;
    }
    public void SetAsteroidCounter(int asteroid)
    {
        asteroidCounter.text = "asteroid restant: " + asteroid;
    }
    public void PhysicsRefresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        
    }

    public void SecondInitialization()
    {
        counterField = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();

        asteroidCounter = GameObject.FindGameObjectWithTag("AsteroidCounter").GetComponent<Text>();
        liveCounter = GameObject.FindGameObjectWithTag("LiveCounter").GetComponent<Text>();
        waveCounter = GameObject.FindGameObjectWithTag("WaveCounter").GetComponent<Text>();
    }
}
