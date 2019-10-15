using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : IManager
{
    #region singleton
    private static WorldManager instance;
    private WorldManager() { }
    public static WorldManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WorldManager();
            }
            return instance;
        }
    }
    #endregion
    GameObject[] worldPlane;
    Transform player;
    float planeX;
    float planeY;

    public void FirstInitialization()
    {
        worldPlane = GameObject.FindGameObjectsWithTag("World");
        planeX = worldPlane[0].transform.localScale.x * 10;
        planeY = worldPlane[0].transform.localScale.z * 10;
    }

    public void PhysicsRefresh()
    {
        
    }

    public void Refresh()
    {
        Transform planeOn = null ;
        foreach(GameObject plane in worldPlane)
        {
            if (player.position.x > plane.transform.position.x - (planeX / 2) && player.position.x < plane.transform.position.x + (planeX / 2))
            {
                if (player.position.y > plane.transform.position.y - (planeY / 2) && player.position.y < plane.transform.position.y + (planeY / 2))
                {
                    planeOn = plane.transform;
                    break;
                }
            }
        }
        Vector2 fakePointUp = new Vector2(planeOn.position.x + planeX, planeOn.position.y + planeY);
        Vector2 fakePointDown = new Vector2(planeOn.position.x - planeX, planeOn.position.y - planeY);
        bool fillUp = true;
        bool fillDown = true;
        bool fillLeft = true;
        bool fillRight = true;
        foreach (GameObject plane in worldPlane)
        {
            
            if (fakePointUp.y > plane.transform.position.y - (planeY / 2) && fakePointUp.y < plane.transform.position.y + (planeY / 2))
            {
                fillUp = false;
            }
            else if (fakePointDown.y > plane.transform.position.y - (planeY / 2) && fakePointDown.y < plane.transform.position.y + (planeY / 2))
            {
                
                fillDown = false;
            }
            else if (fakePointUp.x > plane.transform.position.x - (planeX / 2) && fakePointUp.x < plane.transform.position.x + (planeX / 2))
            {

                fillLeft = false;
            }
            else if (fakePointDown.x > plane.transform.position.x - (planeX / 2) && fakePointDown.x < plane.transform.position.x + (planeX / 2))
            {

                fillRight = false;
            }

        }
        if(fillUp)
        {
            moveDownToUp(planeOn);
        }
        else if (fillDown)
        {
            moveUpToDown(planeOn);
        }
        else if (fillLeft)
        {
            moveRightToLeft(planeOn);
        }
        else if (fillRight)
        {
            moveLeftToRight(planeOn);
        }
    }
    public void SetPlayerPosition(Transform p)
    {
        player = p;
    }
    public void SecondInitialization()
    {
        
    }
    private void moveDownToUp(Transform planeOn)
    {
        //Vector2 fakePoint = new Vector2(planeOn.position.x + 50, planeOn.position.y + 30);
        Vector2 fakePoint = new Vector2(planeOn.transform.position.x, planeOn.transform.position.y - (30 * 2));
        foreach (GameObject plane in worldPlane)
        {
            if (fakePoint.y > plane.transform.position.y - 15 && fakePoint.y < plane.transform.position.y + 15)
            {
                plane.transform.position += new Vector3(0, 30 * 3, 0);
            }


        }
    }
    private void moveUpToDown(Transform planeOn)
    {
        //Vector2 fakePoint = new Vector2(planeOn.position.x + 50, planeOn.position.y + 30);
        Vector2 fakePoint = new Vector2(planeOn.transform.position.x, planeOn.transform.position.y + (30 * 2));
        foreach (GameObject plane in worldPlane)
        {
            if (fakePoint.y > plane.transform.position.y - 15 && fakePoint.y < plane.transform.position.y + 15)
            {
                plane.transform.position -= new Vector3(0, 30 * 3, 0);
            }


        }
    }
    private void moveRightToLeft(Transform planeOn)
    {
        //Vector2 fakePoint = new Vector2(planeOn.position.x + 50, planeOn.position.y + 30);
        Vector2 fakePoint = new Vector2(planeOn.transform.position.x - (50 * 2), planeOn.transform.position.y);
        foreach (GameObject plane in worldPlane)
        {
            if (fakePoint.x > plane.transform.position.x - 15 && fakePoint.x < plane.transform.position.x + 15)
            {
                plane.transform.position += new Vector3(50 * 3, 0, 0);
                //Debug.Log("bob");
            }


        }
    }
    private void moveLeftToRight(Transform planeOn)
    {
        //Vector2 fakePoint = new Vector2(planeOn.position.x + 50, planeOn.position.y + 30);
        Vector2 fakePoint = new Vector2(planeOn.transform.position.x + (50 * 2), planeOn.transform.position.y);
        foreach (GameObject plane in worldPlane)
        {
            if (fakePoint.x > plane.transform.position.x - 15 && fakePoint.x < plane.transform.position.x + 15)
            {
                plane.transform.position -= new Vector3(50 * 3, 0, 0);
                //Debug.Log("bob");
            }


        }
    }


}
