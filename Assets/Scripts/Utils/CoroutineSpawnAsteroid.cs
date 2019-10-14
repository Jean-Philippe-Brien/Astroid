using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSpawnAsteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public static CoroutineSpawnAsteroid instance;
    private void Start()
    {
        instance = this;
    }
    public static void SpawnAsteroid(GameObject asteroid, float waitStart)
    {
        instance.StartCoroutine(instance.CoroutinespawnAsteroid(asteroid, waitStart));
    }
    public IEnumerator CoroutinespawnAsteroid(GameObject asteroid, float waitStart)
    {
        
        Collider2D hit;
        yield return new WaitForSeconds(waitStart);
        do
        {
            Vector2 rotatePoint = RotatePoint(Random.Range(0f, 360f), 20);
            hit = Physics2D.OverlapCircle(rotatePoint, 5, LayerMask.GetMask("Meteor"));
            if (hit == null)
            {
                GameObject newAsteroid = GameObject.Instantiate(asteroid);
                newAsteroid.transform.position = rotatePoint;
                WaveManager.Instance.asteroids.Add(newAsteroid.GetComponent<Asteroid>());
                
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        } while (hit != null);
        yield return null;
    }
    public Vector2 RotatePoint(float DegAngle, float rayonSpawn)
    {
        float cx = PlayerManager.Instance.player.transform.position.x;
        float cy = PlayerManager.Instance.player.transform.position.y;
        Vector2 p = new Vector2(cx + rayonSpawn, cy);
        float angle = (DegAngle) * Mathf.PI / 180;
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
}
