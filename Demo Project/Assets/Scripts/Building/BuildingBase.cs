using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    public static Action UpdatePathfinder;
    public int health;

    public abstract void Start();

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
            UpdatePathfinder?.Invoke();
        }
    }
}
