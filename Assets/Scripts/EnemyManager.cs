using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    public List<Enemy> enemiesInRange = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        enemiesInRange.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    
    void Update()
    {
        
    }
}
