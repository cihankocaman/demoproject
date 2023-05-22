using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    public static Action UpdatePathfinder;

    public GameObject healthBar;
    private float decreaseAmount;

    public int health;

    public virtual void Start()
    {
        decreaseAmount = 1f / (float)health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - ( decreaseAmount * damageAmount), healthBar.transform.localScale.y);
        if (health <= 0)
        {
            Destroy(gameObject);
            UpdatePathfinder?.Invoke();
        }
    }
}
