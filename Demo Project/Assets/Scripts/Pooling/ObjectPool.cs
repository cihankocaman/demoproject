using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : SingletonCreator<ObjectPool>
{
    public GameObject scrollViewContent;

    public List<ObjectPrefab> pooledGameObjects;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    protected override void Awake()
    {
        base.Awake();
        CreatePool(pooledGameObjects);
    }
    private void CreatePool(List<ObjectPrefab> poolGameObj)
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (ObjectPrefab item in pooledGameObjects)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                //obj.SetActive(false);
                obj.transform.parent = scrollViewContent.transform;
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(item.Name, objectPool);
        }
    }

    public GameObject GetObjFromPool(string name, Vector3 targetPos, Quaternion rotation)
    {
        if (poolDictionary[name].Count <= 1)
        {
            GameObject lastObjInQueue = poolDictionary[name].Dequeue();
            GameObject newInstantiatedObj = Instantiate(lastObjInQueue, transform);
            poolDictionary[name].Enqueue(lastObjInQueue);
            poolDictionary[name].Enqueue(newInstantiatedObj);
        }

        if (!poolDictionary.ContainsKey(name))
        {
            return null;
        }

        GameObject spawnedObj = poolDictionary[name].Dequeue();
        spawnedObj.SetActive(true);
        spawnedObj.transform.position = targetPos;
        spawnedObj.transform.rotation = rotation;

        return spawnedObj;
    }
    public void ReturnObjToPool(GameObject go, string prefabName)
    {
        go.SetActive(false);
        poolDictionary[prefabName].Enqueue(go);
    }
}
