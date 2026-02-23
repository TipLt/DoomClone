using UnityEngine;

public class ItemRotator : MonoBehaviour
{
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = target.position - transform.position;
        lookDir.y = 0;
        if (lookDir.sqrMagnitude > 0.001f)
        {
            transform.forward = lookDir.normalized;
        }
    }
}
