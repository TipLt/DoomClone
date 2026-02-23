using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    
    
    
    private float enemyHealth = 2f;




    public GameObject gunHitEffect;
    
    void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyManager = FindFirstObjectByType<EnemyManager>();
    }


    void Update()
    {

        //beginning of update set the sprite animation to the correct angle
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);
        if (enemyHealth <= 0f)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }


        //any animation we call will update index
    }
    public void TakeDamage(float amount)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= amount;
    }

}
