using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    private float enemyHealth = 2f;


    public GameObject gunHitEffect;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (enemyHealth <= 0f)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float amount)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= amount;
    }

}
