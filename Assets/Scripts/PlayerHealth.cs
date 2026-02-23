using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;


    public int maxArmor;
    private int armor;
    void Start()
    {
        health = maxHealth;
        UICanvasManager.Instance.UpdateHealth(health);
        UICanvasManager.Instance.UpdateArmor(armor);
    }

    void Update()
    {
        //test function to damage player
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player Damaged! Current armor: " + armor);
            //after armor brak
            Debug.Log("Current health: " + health);
        }
    }

    public void DamagePlayer(int damage)
    {

        //if the player has armor damge it instead


        //if the player has enough armor to absorb all the damge the only damage the armor

        //if the player has enough armor to absorb some of the damge
        //then damage the armor first and then damage the player

        if (armor > 0)
        {
            //damge armor
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                int remainingDamage;
                remainingDamage = damage - armor;
                armor = 0;
                health -= remainingDamage;
            }

        }
        else
        {
            health -= damage;
        }


        if (health <= 0)
        {
            Debug.Log("Player Died!");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        UICanvasManager.Instance.UpdateHealth(health);
        UICanvasManager.Instance.UpdateArmor(armor);
    }

    public void GiveHealth(int amount,GameObject pickup)
    {

        if(health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }
        
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        UICanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {

        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }
        
        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        UICanvasManager.Instance.UpdateArmor(armor);

        Debug.Log("Player Armor: " + armor);
    }
}
