using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierBase : MonoBehaviour
{
    public int damage;
    public int health;

    public virtual void Start()
    {
        health = 10;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
