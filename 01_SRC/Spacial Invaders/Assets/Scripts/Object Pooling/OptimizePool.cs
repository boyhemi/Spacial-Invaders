using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizePool : MonoBehaviour
{
    public GameObject poolingObject;

    public GameObject parentObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

 // Use this for initialization
      void Start () {
      pooledObjects = new List<GameObject>();

        for(int i =0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(poolingObject, parentObject.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
  

 }

    public GameObject GetPooledObject()
    {
        for(int i=0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = Instantiate(poolingObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;


    }
}
