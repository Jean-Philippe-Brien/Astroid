using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IManager
{
    #region singleton
    private static EnemyManager instance;
    private EnemyManager() { }
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EnemyManager();
            }
            return instance;
        }
    }
    #endregion
    List<Enemy> enemys;
    GameObject enemy;
    public void FirstInitialization()
    {
        enemys = new List<Enemy>();
        enemy = Resources.Load<GameObject>("Prefabs/Enemy");

    }
    public void AddEnemy()
    {
        GameObject enemy = GameObject.Instantiate<GameObject>(this.enemy);
        enemy.GetComponent<Enemy>().FirstInitialization();
        enemy.transform.position = Vector3.zero;
        enemys.Add(enemy.GetComponent<Enemy>());
    }
    public void PhysicsRefresh()
    {
        foreach(Enemy enemy in enemys)
        {
            enemy.FixedRefresh();
        }
    }

    public void Refresh()
    {
        foreach (Enemy enemy in enemys)
        {
            enemy.Refresh();
        }
    }

    public void SecondInitialization()
    {
        throw new System.NotImplementedException();
    }
}
