using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierBase : MonoBehaviour
{
    public int damage;
    public int health;
    public GameObject healthBar;

    private float decreaseAmount;

    public virtual void Start()
    {
        health = 10;

        decreaseAmount = 1f / (float)health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - (decreaseAmount * damageAmount), healthBar.transform.localScale.y);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
