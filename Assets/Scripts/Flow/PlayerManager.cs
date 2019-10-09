using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IManager
{
    Player player;
    #region Singleton
    private static PlayerManager instance;
    private PlayerManager() { }
    public static PlayerManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    #endregion
    public void FirstInitialization()
    {
        //GameObject newPlayer = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), GameLinks.gl.spawnPlayer);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //player.transform.position = GameLinks.gl.spawnPlayer.transform.position;
        player.FirstInitialization();
        
    }

    public void PhysicsRefresh()
    {
        player.PhysicsRefresh(InputManager.Instance.physicsInputPkg);
    }

    public void Refresh()
    {
        player.Refresh(InputManager.Instance.UpdateInputPkg);
    }

    public void SecondInitialization()
    {
        
    }
}
