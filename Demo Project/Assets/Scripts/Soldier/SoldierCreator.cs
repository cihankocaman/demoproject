using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCreator : MonoBehaviour
{
    private Placement placeBuilding;
    private GameObject[] soldierPlaces;
    public GameObject soldier;
    private float soldierProduceTime = 1f;
    private int soldierCount = 0;
    private bool isFull; //Max soldier produce capacity 6. If soldier count reaches 6 isFull = true

    private void Start()
    {
        placeBuilding = GetComponent<Placement>();

        soldierPlaces = new GameObject[6];
        for (int i = 0; i < soldierPlaces.Length; i++)
        {
            soldierPlaces[i] = transform.GetChild(i).gameObject;
        }
    }
    private void Update()
    {
        if (placeBuilding.isPlaced)
        {
            ProduceSoldier();
        }
    }

    private void ProduceSoldier()
    {
        soldierProduceTime -= Time.deltaTime;
        if (soldierProduceTime <= 0 && !isFull)
        {
            soldierProduceTime = 1f;
            Instantiate(soldier, soldierPlaces[soldierCount].transform.position, Quaternion.identity);
            soldierCount++;
            if (soldierCount == 6)
            {
                isFull = true;
            }
        }
    }
}
