using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour, IAttack
{
    private SoldierBase soldierBase;

    private void Start()
    {
        soldierBase = GetComponent<SoldierBase>();
    }
    public void Attack(GameObject targetEnemy)
    {
        StartCoroutine(RepeatAttack(targetEnemy));
    }

    public IEnumerator RepeatAttack(GameObject targetEnemy)
    {
        while (targetEnemy != null)
        {
            Debug.Log("coroutine");
            if (targetEnemy.CompareTag("soldier"))
            {
                targetEnemy.GetComponent<SoldierBase>().TakeDamage(soldierBase.damage);
            }
            else if (targetEnemy.CompareTag("building"))
            {
                targetEnemy.GetComponent<BuildingBase>().TakeDamage(soldierBase.damage);
            }
            yield return new WaitForSeconds(3f);
        }

        if (targetEnemy == null)
        {
            StopCoroutine("RepeatAttack");
        }
    }
}
