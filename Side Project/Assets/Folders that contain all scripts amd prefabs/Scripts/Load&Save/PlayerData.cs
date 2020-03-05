using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int maxHP = 100;
    public int maxMP = 100;
    public int hp = 100;
    public int mp = 100;
    public string namePlayer = "Bob";
    public int damage = 10;
    public int healPool = 5;

    public bool TakeDamage(int dmg)
    {
        hp -= dmg; // Reduce the hp of the player by the damage

        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void healing()
    {
        hp += healPool; // Increase the hp of the player
        if(hp > maxHP)
        {
            hp = maxHP; // if hp more than max hp, change hp to be equal to maxHhp
        }
    }
}
