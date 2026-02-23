using UnityEngine;

public class Door : MonoBehaviour
{

    public Animator doorAnim;
    public bool requiresKey;

    public bool reqRed, reqBlue, reqYellow;
    public GameObject areaToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (requiresKey)
            {
                if(reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    //open door animation
                    doorAnim.SetTrigger("OpenDoor");

                    //spawn enemy in area

                   // areaToSpawn.SetActive(true);
                }
                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    //open door animation
                    doorAnim.SetTrigger("OpenDoor");

                    //spawn enemy in area

                   // areaToSpawn.SetActive(true);

                }
                if(reqYellow && other.GetComponent<PlayerInventory>().hasYellow)
                {
                    //open door animation
                    doorAnim.SetTrigger("OpenDoor");

                    //spawn enemy in area

                   // areaToSpawn.SetActive(true);
                }
            }
            else
            {
                //open door animation
                doorAnim.SetTrigger("OpenDoor");

            //spawn enemy in area

            areaToSpawn.SetActive(true);
            }


        }
    }
}
