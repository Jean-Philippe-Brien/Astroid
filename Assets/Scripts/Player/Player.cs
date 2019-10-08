using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    float rotationSpeed;
    float counterBetweenFire;
    bool canFire;
    GameObject bullet;
    public float speed = 5;
    public float timeBetweenFire;
    public float maxSpeed;
    
    public void FirstInitialization()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        rbPlayer = GetComponent<Rigidbody2D>();
        rotationSpeed = 5;
        canFire = true;
        counterBetweenFire = timeBetweenFire;
    }
    public void Refresh(InputManager.InputPkg inputPck)
    {
        if(canFire)
        {
            if(inputPck.fire)
            {
                GameObject ball = GameObject.Instantiate(bullet, transform.position + transform.up * 1, Quaternion.identity, transform.parent);
                ball.transform.eulerAngles = transform.eulerAngles;
                canFire = false;
            }
        }
        else
        {

            if (counterBetweenFire <= 0)
            {
                canFire = true;
                counterBetweenFire = timeBetweenFire;
            }
            else
                counterBetweenFire -= Time.deltaTime;
        }
    }
    public void PhysicsRefresh(InputManager.InputPkg inputPck)
    {
        transform.localEulerAngles += (-Vector3.forward) * inputPck.dirPressed.x * rotationSpeed;
        rbPlayer.AddRelativeForce(Vector2.up * inputPck.dirPressed * speed);
        Vector2 velo = new Vector2(Mathf.Clamp(rbPlayer.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rbPlayer.velocity.y, -maxSpeed, maxSpeed));
        rbPlayer.velocity = velo;
    }
}
