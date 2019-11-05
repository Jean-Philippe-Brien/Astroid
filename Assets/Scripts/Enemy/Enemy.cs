using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 dir;
    float speed;
    Rigidbody2D rb;
    GameObject bulletEnemy;
    float timeBetweenFire = 3;
    bool isAlive = true;
    public void FirstInitialization()
    {
        bulletEnemy = Resources.Load<GameObject>("Prefabs/BulletEnemy");
        speed = Random.Range(1f, 2f);
        RandomizeDirection();
        rb = GetComponent<Rigidbody2D>();
    }
    public void RandomizeDirection()
    {
        dir = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
    }
    public void Refresh()
    {
        if (isAlive)
        {
            float distance = Vector2.Distance(PlayerManager.Instance.player.transform.position, transform.position);
            Vector3 diff = PlayerManager.Instance.player.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (PlayerManager.Instance.player.gameObject.active == true)
            {
                timeBetweenFire -= Time.deltaTime;
                if (distance <= 10 && timeBetweenFire <= 0)
                {
                    timeBetweenFire = 1;
                    GameObject bullet = GameObject.Instantiate(bulletEnemy);
                    //Vector3 shoot = (target.position - ball.transform.position).normalized;
                    bullet.transform.position = transform.position;
                    bullet.transform.eulerAngles = transform.eulerAngles;
                    bullet.GetComponent<BallMovement>().enemy = true;
                }
            }
            if (distance > 20)
            {
                transform.position = RotatePoint();
            }
        }
    }
    public void FixedRefresh()
    {
        rb.AddRelativeForce(dir * speed);
        Vector2 velo = new Vector2(Mathf.Clamp(rb.velocity.x, -2, 2), Mathf.Clamp(rb.velocity.y, -2, 2));
        rb.velocity = velo;
    }
    public Vector2 RotatePoint()
    {
        Vector2 p = transform.position;
        float cx = GameLinks.gl.player.transform.position.x;
        float cy = GameLinks.gl.player.transform.position.y;
        float angle = (180) * Mathf.PI / 180;
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        p.x -= cx;
        p.y -= cy;
        float xnew = p.x * c - p.y * s;
        float ynew = p.x * s + p.y * c;
        p.x = xnew + cx;
        p.y = ynew + cy;
        return p;
    }
    public void Die()
    {
        isAlive = false;
        Destroy(gameObject);
    }
}
