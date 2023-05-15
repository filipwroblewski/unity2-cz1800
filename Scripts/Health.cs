using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 100.0f;

    public void dmgDealt(float dmg)
    {
        healthPoints = healthPoints - dmg;
        Debug.Log($"Hp: {healthPoints}");
    }

    public bool isAlive()
    {
        if (healthPoints > 0)
            return true;
        else
            return false;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
