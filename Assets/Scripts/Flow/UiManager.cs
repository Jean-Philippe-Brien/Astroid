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
    int timeCoolDown = 0;
    Text CpCoolDown;
    float coolDown;

    public void SetCoolDown(int coolDown)
    {
        this.coolDown = coolDown;
    }
    public void FirstInitialization()
    {
        CpCoolDown = GameObject.FindGameObjectWithTag("Counter").GetComponent<Text>();
    }

    public void PhysicsRefresh()
    {
        throw new System.NotImplementedException();
    }

    public void Refresh()
    {
        if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if((int)coolDown != timeCoolDown)
            {
                timeCoolDown = (int)coolDown + 1;
                CpCoolDown.text = timeCoolDown.ToString();
            }
        }
        else
        {
            if (CpCoolDown.enabled == true)
                CpCoolDown.enabled = false;
        }
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
}
