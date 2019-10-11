using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Start is called before the first frame update
    int timeCoolDown = 0;
    Text CpCoolDown;
    float coolDown;
    public void SetCoolDown(int coolDown)
    {
        this.coolDown = coolDown;
        GetComponent<Text>().enabled = true;
    }
    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if ((int)coolDown != timeCoolDown)
            {
                timeCoolDown = (int)coolDown + 1;
                GetComponent<Text>().text = timeCoolDown.ToString();
            }
        }
        else
        {
            if (GetComponent<Text>().enabled)
                GetComponent<Text>().enabled = false;
        }
    }
}
