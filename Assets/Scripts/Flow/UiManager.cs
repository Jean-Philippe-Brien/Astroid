using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Counter counterField;
    public void FirstInitialization()
    {
        counterField = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();
    }
    public void SetCoolDown(int coolDown)
    {
        counterField.SetCoolDown(coolDown);
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
        throw new System.NotImplementedException();
    }
}
