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
    bool menuOn = true;
    bool isPaused = false;
    float TimeBeforeStart = 3;
    public void FirstInitialization()
    {
        GameLinks.gl = GameObject.FindObjectOfType<GameLinks>();
        UiManager.Instance.FirstInitialization();
        UiManager.Instance.SetCoolDown(3);
        WaveManager.Instance.FirstInitialization();
        WorldManager.Instance.FirstInitialization();
        InputManager.Instance.FirstInitialization();
        PlayerManager.Instance.FirstInitialization();
        //UiManager.Instance.SetCoolDown(3);
    }
    //like start func
    public void SecondInitialization()
    {
        InputManager.Instance.SecondInitialization();
        PlayerManager.Instance.SecondInitialization();
    }
    public void Refresh()
    {
        UiManager.Instance.Refresh();
        InputManager.Instance.Refresh();
        PlayerManager.Instance.Refresh();
        WorldManager.Instance.SetPlayerPosition(PlayerManager.Instance.player.transform);
        WorldManager.Instance.Refresh();
        
    }
    public void PhysicsRefresh()
    {
        if (!isPaused)
        {
            InputManager.Instance.PhysicsRefresh();
            PlayerManager.Instance.PhysicsRefresh();
        }
    }
}
