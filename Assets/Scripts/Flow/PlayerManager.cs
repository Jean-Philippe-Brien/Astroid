using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : IManager
{
    public Player player;
    public bool isAlive;
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
        isAlive = true;
        //player.transform.position = GameLinks.gl.spawnPlayer.transform.position;
        player.FirstInitialization();
        
    }
    public void RespawnPlayer()
    {
        player.gameObject.SetActive(true);
    }
    public void playerDeath()
    {

    }
    public void setCanFire()
    {
        player.canShoot = true;
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
