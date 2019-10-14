using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    float rotationSpeed;
    float counterBetweenFire;
    bool canFire;
    public bool canShoot;
    GameObject bullet;
    public float speed = 5;
    public float timeBetweenFire;
    public float maxSpeed;
    public int live = 3;

    public void FirstInitialization()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        rbPlayer = GetComponent<Rigidbody2D>();
        rotationSpeed = 150.5f;
        canFire = true;
        canShoot = false;
        counterBetweenFire = timeBetweenFire;
    }
    public void Refresh(InputManager.InputPkg inputPck)
    {
        if (live > 0)
        {
            if (canShoot)
            {
                if (canFire)
                {
                    if (inputPck.fire)
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
        }
        else
        {
            PlayerManager.Instance.playerDeath();
        }
    }
    public void PhysicsRefresh(InputManager.InputPkg inputPck)
    {
        transform.localEulerAngles += ((-Vector3.forward) * inputPck.dirPressed.x) * rotationSpeed * Time.fixedDeltaTime;
        rbPlayer.AddRelativeForce(Vector2.up * inputPck.dirPressed * speed);
        Vector2 velo = new Vector2(Mathf.Clamp(rbPlayer.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rbPlayer.velocity.y, -maxSpeed, maxSpeed));
        rbPlayer.velocity = velo;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Meteor")
        {
            GameObject.Instantiate(GameLinks.gl.explosion, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            GameLinks.gl.explosion.GetComponent<ParticleSystem>().Play();
            UiManager.Instance.SetCoolDownRespawn(3);
            live--;
            UiManager.Instance.SetLiveCounter(live);
            canShoot = false;
            gameObject.SetActive(false);
        }
    }
}
