using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool isRedKey, isBlueKey, isYellowKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
                UICanvasManager.Instance.UpdateKeys("red");
            }

            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
                UICanvasManager.Instance.UpdateKeys("blue");

            }

            if (isYellowKey)
            {
                other.GetComponent<PlayerInventory>().hasYellow = true;
                UICanvasManager.Instance.UpdateKeys("yellow");
            }

            Destroy(gameObject);
        }
    }
}