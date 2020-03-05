using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetEnemyHUD(EnemyCreator enemy)
    {
        nameText.text = enemy.name; //Sets name text to the enemy's name
        hpSlider.maxValue = enemy.maxHp; // Sets the maxValue of the slider to the enemies maxHp
        hpSlider.value = enemy.Hp; // Sets the value of the slider to the enemy's Hp
    }

    public void SetPlayerHUD(PlayerData player)
    {
        nameText.text = player.namePlayer;
        hpSlider.maxValue = player.maxHP;
        hpSlider.value = player.hp;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp; // Adjusts only the value of the slider
    }
}
