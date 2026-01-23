using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playerTransform;
    private NavMeshAgent enemyNavMeshAgent;


    private float updateInterval = 0.5f;

    private float nextUpdateTime;


    private float moveThreshold = 1f;
    private Vector3 lastTargetPosition;
    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        //playerTransform = FindAnyObjectByType<PlayerMovement>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();

        var player = FindAnyObjectByType<PlayerMovement>();
        if (player != null)
        {
            playerTransform = player.transform;
        }

        enemyNavMeshAgent.avoidancePriority = Random.Range(30, 60);
    }

    private void Update()
    {

        if (playerTransform == null || Time.time < nextUpdateTime) return;

        nextUpdateTime = Time.time + updateInterval;

        if (enemyAwareness.isAggro)
        {
            if ((playerTransform.position - lastTargetPosition).sqrMagnitude > moveThreshold * moveThreshold)
            {
                enemyNavMeshAgent.SetDestination(playerTransform.position);
                lastTargetPosition = playerTransform.position;
            }
        }
        else
        {
            if (enemyNavMeshAgent.hasPath)
            {
                enemyNavMeshAgent.ResetPath();
            }

        }
    }
}
