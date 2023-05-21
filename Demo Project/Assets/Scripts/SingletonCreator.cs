using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCreator<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singlegameObj = new GameObject(typeof(T).Name);
                instance = singlegameObj.AddComponent<T>();
            }
            return instance;
        }

    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>();
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
