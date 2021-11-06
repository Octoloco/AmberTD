using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Queue<GameObject> objectPool;

    private void Start()
    {
        objectPool = new Queue<GameObject>();
        CreateObject(10);
    }

    public GameObject GetObjectFromPool()
    {
        if (objectPool.Count <= 0)
        {
            CreateObject(1);
        }

        return objectPool.Dequeue();
    }

    public void AddToQueue(GameObject objectToQueue)
    {
        objectPool.Enqueue(objectToQueue);
    }

    private void CreateObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate(prefab, transform);
            objectPool.Enqueue(temp);
        }
    }
}
