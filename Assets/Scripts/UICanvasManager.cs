using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1; //fully healthy
    public Sprite health2; //slightly injured
    public Sprite health3; //moderately injured
    public Sprite health4; //dead


    public GameObject redKey;
    public GameObject blueKey;
    public GameObject yellowKey;

    private static UICanvasManager instance;
    public static UICanvasManager Instance 
    { 
        
        get { return instance; } 
    
    }

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        health.text = currentHealth.ToString() + "%";
        UpdateHealthIndicator(currentHealth);
    }

    public void UpdateArmor(int currentArmor)
    {
        armor.text = currentArmor.ToString() + "%";
    }

    public void UpdateAmmo(int currentAmmo)
    {
        ammo.text = currentAmmo.ToString();
    }

    public void UpdateHealthIndicator(int currentHealth)
    {
        if (currentHealth >= 75)
        {
            healthIndicator.sprite = health1;
        }
        else if (currentHealth >= 50)
        {
            healthIndicator.sprite = health2;
        }
        else if (currentHealth > 0)
        {
            healthIndicator.sprite = health3;
        }
        else
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
      switch (keyColor)
        {
            case "red":
                redKey.SetActive(true);
                break;
            case "blue":
                blueKey.SetActive(true);
                break;
            case "yellow":
                yellowKey.SetActive(true);
                break;
        }
    }

    public void ClearKey()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        yellowKey.SetActive(false);
    }
}
