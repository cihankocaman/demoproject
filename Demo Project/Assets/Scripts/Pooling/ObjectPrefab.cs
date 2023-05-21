using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPrefab
{
    public string Name { get => prefab.name; }
    public GameObject prefab;
    public int size;
}
