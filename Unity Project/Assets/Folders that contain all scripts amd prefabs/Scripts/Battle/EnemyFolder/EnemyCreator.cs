using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Enemy/Unit")]
public class EnemyCreator : ScriptableObject
{
    public string unitName = "New Unit";
    public Sprite icon = null;
    public int damage = 10;
    public int maxHp = 100;
    public int Hp = 100;
    public int heal = 5;
    public Items rewards;

    public bool TakeDamage(int dmg) // For taking damage
    {
        Hp -= dmg; // Reduce Hp by the damage

        if (Hp <= 0)
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
        Hp += heal; // Adds Hp by the heal interger
        if (Hp > maxHp)
        {
            Hp = maxHp; // if the maxHp is lesser than the Hp, change the value of the Hp to be equal to the maxHp
        }
    }
}
