using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public bool hasRed, hasBlue, hasYellow;

    private void Start()
    {
        UICanvasManager.Instance.ClearKey();
    }
}
