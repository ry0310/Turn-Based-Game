using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject healthPool; // Object containing the images for the border and to fill the border
    [SerializeField]
    Slider healthSlider; // The slider attatched to the fill image
    [SerializeField]
    Slider manaSlider; // Slider attatched to fill the mana
    [SerializeField]
    Image healthFill;

    PlayerData player; // Player's data
    public void Start()
    {
        healthPool.SetActive(true); // Set the health pool to true

        SetMaxHealth(player.maxHP); // Set the maxHp and maxMP to the player's maxHp and MP
        SetMaxMana(player.maxMP);
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health; // Sets the maxValue and value of the slider to the player's maxHp
        healthSlider.value = health;
    }

    public void SetMaxMana(int mana)
    {
        manaSlider.maxValue = mana; // Sets the maxValue and value of the slider to the player's maxMP
        manaSlider.value = mana;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health; // Sets the value of the slider to the current health of the player
        
        if (healthSlider.value < 40)
        {
            healthFill.color = Color.red; // if the value is less than 40, change the fill image to red
        }
        else if (healthSlider.value < 80)
        {
            healthFill.color = Color.yellow; // If it is less than 80, change it to orange
        }
    }
    public void SetMana(int mana)
    {
        manaSlider.value =  mana;
    }
}
