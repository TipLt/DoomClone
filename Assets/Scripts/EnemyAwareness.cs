using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{

    public bool isAggro;
    public Material aggroMat;
    public float awarenessRadius = 8f;
    private Transform playerTransform;

    private MeshRenderer meshRenderer;
    private float checkInterval = 0.2f;
    private float nextCheckTime;
    private float awarenessSqrRadius;

    private void Start()
    {
        var player = FindAnyObjectByType<PlayerMovement>().transform;
        if(player != null)
        {
            playerTransform = player;
        }
        meshRenderer = GetComponent<MeshRenderer>();
        awarenessSqrRadius = awarenessRadius * awarenessRadius;
    }

    private void Update()
    {
        if (isAggro || playerTransform == null) return;
        if (Time.time < nextCheckTime) return;
        nextCheckTime = Time.time + checkInterval;
        var distSqr = (transform.position - playerTransform.position).sqrMagnitude;

        if (distSqr < awarenessSqrRadius)
        {
            isAggro = true;
            meshRenderer.material = aggroMat;

        }

    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = aggroMat;
            isAggro = true;
        }
    }*/
}
