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
    int typeCoolDown;
    public void SetCoolDown(int coolDown, int type)
    {
        this.coolDown = coolDown;
        GetComponent<Text>().enabled = true;
        transform.GetChild(0).GetComponent<Text>().enabled = true;
        typeCoolDown = type;
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
                if (typeCoolDown == 0)
                    transform.GetChild(0).GetComponent<Text>().text = "wave start in";
                else if (typeCoolDown == 1)
                    transform.GetChild(0).GetComponent<Text>().text = "Respawn in";
            }
        }
        else
        {
            if (GetComponent<Text>().enabled)
            {
                GetComponent<Text>().enabled = false;
                transform.GetChild(0).GetComponent<Text>().enabled = false;
                if (typeCoolDown == 0)
                    WaveManager.Instance.waveStart = true;
                else if (typeCoolDown == 1)
                    PlayerManager.Instance.RespawnPlayer();
            }
        }
    }
}
