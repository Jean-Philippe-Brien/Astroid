using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : IManager
{
    #region singleton
    private static GameFlow instance;
    private GameFlow() { }
    public static GameFlow Instance {
        get
        {
            if(instance == null)
            {
                instance = new GameFlow();
            }
            return instance;
        }
    }
    #endregion
    //like awake func
    bool isPaused = false;
    public void FirstInitialization()
    {
        UiManager.Instance.FirstInitialization();
        GameLinks.gl = GameObject.FindObjectOfType<GameLinks>();
        WorldManager.Instance.FirstInitialization();
        InputManager.Instance.FirstInitialization();
        PlayerManager.Instance.FirstInitialization();
        
        
    }
    //like start func
    public void SecondInitialization()
    {
        UiManager.Instance.SecondInitialization();

        WaveManager.Instance.SecondInitialization();
        InputManager.Instance.SecondInitialization();
        PlayerManager.Instance.SecondInitialization();
    }
    public void Refresh()
    {
        
        InputManager.Instance.Refresh();
        PlayerManager.Instance.Refresh();
        WorldManager.Instance.SetPlayerPosition(PlayerManager.Instance.player.transform);
        WorldManager.Instance.Refresh();
        UiManager.Instance.Refresh();
        WaveManager.Instance.Refresh();
        

    }
    public void PhysicsRefresh()
    {
        InputManager.Instance.PhysicsRefresh();
        PlayerManager.Instance.PhysicsRefresh();
        
    }
}
