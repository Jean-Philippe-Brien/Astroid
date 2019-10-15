using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Asteroid : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    Vector2[] coledge;
    
    int[] triangles;
    int nbCorner;
    float rangeAngle;
    float seed;
    public float size;
    public int subDivision;
    LineRenderer lineRend;
    PolygonCollider2D edgeCol2D;
    Rigidbody2D rb;

    public void FirstInitialization(float _size)
    {
        size = _size;
        mesh = new Mesh();
        seed = Random.Range(0, 20f);
        if ((int)(size / 3) >= 2)
        {
            subDivision = 3;
        }
        else if ((int)(size / 2) >= 2)
        {
            subDivision = 2;
        }
        else
        {
            subDivision = 0;
        }

        edgeCol2D = GetComponentInChildren<PolygonCollider2D>();
        lineRend = GetComponentInChildren<LineRenderer>();
        rb = GetComponentInChildren<Rigidbody2D>();
        GetComponentInChildren<MeshFilter>().mesh = mesh;

        lineRend.loop = true;
        CreateShape();
        UpdateMesh();
        float asteroidSize = size / 6 > 8 ? 8 : size;
        transform.localScale = new Vector3(asteroidSize, asteroidSize, asteroidSize);
        Move();
    }

    void Move()
    {
        rb.AddForce(Random.insideUnitCircle * Random.Range(3f, 6.5f), ForceMode2D.Impulse);
    }
    void CreateShape()
    {
        //nbCorner = (int)size < 2? 6 : ((int)(size / 2)) * 6;
        nbCorner = (int)size < 4? 6 : 12;
        lineRend.positionCount = nbCorner;
        rangeAngle = 360 / nbCorner;

        //Cos(angle) = x
        //Sin(angle) = y
        Vector3[] linePos = new Vector3[nbCorner];
        vertices = new Vector3[nbCorner + 1];
        coledge = new Vector2[nbCorner + 1];
        int circleSize = vertices.Length;
        //Generate vertices point
        vertices[0] = new Vector3(0, 0, 0);
        float angle = 0;
        for (int i = 1; i < circleSize; i++)
        {
            float x = Mathf.Cos(angle * Mathf.PI / 180);
            float y = Mathf.Sin(angle * Mathf.PI / 180);
            float noise = Mathf.PerlinNoise(seed + x, seed + y);
            vertices[i] = noise * new Vector3(x, y);
            coledge[i - 1] = noise * new Vector3(x, y);
            linePos[i - 1] = noise * new Vector3(x, y);
            angle += rangeAngle;
        }
        coledge[coledge.Length - 1] = coledge[0];
        lineRend.SetPositions(linePos);

        triangles = new int[(circleSize * 3)];
        //Generate triangles on vertices
        int tris = 0;
        for(int i = 0; i < nbCorner - 1; i++){
            triangles[tris + 0] = 0;
            triangles[tris + 1] = i + 1;
            triangles[tris + 2] = i + 2;
            tris += 3;
        }
        triangles[triangles.Length - 3] = 0;
        triangles[triangles.Length - 2] = nbCorner;
        triangles[triangles.Length - 1] = 1;

        


    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        edgeCol2D.points = coledge;
        mesh.RecalculateNormals();
    }

    

    public void SecondInitialization()
    {
    }
    public void verifyDistanceToPlayer(Vector2 posPlayer)
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, posPlayer);
        if(distanceFromPlayer > 22)
        {
            transform.position = RotatePoint(posPlayer, 180, transform.position);
            Vector2 heading = (Vector2)transform.position - posPlayer;
            float distance = heading.magnitude;
            Vector2 direction = heading / distance; // This is now the normalized direction.
            transform.position -= (Vector3)direction;
        }
    }
    public static Vector2 RotatePoint(Vector2 centerPoint, float DegAngle, Vector2 p)
    {
        float cx = centerPoint.x;
        float cy = centerPoint.y;
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

    public void PhysicsRefresh()
    {
    }

    

    public void Refresh()
    {
        throw new System.NotImplementedException();
    }
    private void OnDestroy()
    {
        
    }
}
