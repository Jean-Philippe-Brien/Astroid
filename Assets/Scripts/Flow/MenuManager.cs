using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Commencer()
    {
        SceneManager.LoadScene(1);
    }
    public static void Quitter()
    {
        Application.Quit();
    }
    private void Update()
    {
       
    }
}
