using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Pool")]
    public static ParticleManager SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectpool;
    public GameObject BlocksHolder;
    public int amountToPool;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for(int i =0; i < amountToPool;i++)
        {
            tmp = Instantiate(objectpool);
            tmp.transform.SetParent(BlocksHolder.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    private void Awake()
    {
        SharedInstance = this;
    }
}
