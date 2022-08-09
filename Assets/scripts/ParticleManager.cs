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

    [SerializeField]
    private Sprite[] blockSprites;

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

    public Sprite SelectBlockSprite(int BlockNum)
    {
        Sprite Block = blockSprites[0];
        switch(BlockNum)
        {
            case 0:     Block= blockSprites[0];
                break;
            case 1:     Block= blockSprites[1];
                break;
            case 2:     Block = blockSprites[2];
                break;
            case 3:     Block = blockSprites[3];
                break;
        }
        return Block;
    }

    private void Awake()
    {
        SharedInstance = this;
    }
}
