/// http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/object-pooling 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolScript : MonoBehaviour
{
    public static ObjectPoolScript current;
    public GameObject c_trainObject;
    public int pooledAmount = 20; // how many objects will be pooled.
    public bool willGrow = true;

    public List<GameObject> pooledTrainObjects;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        pooledTrainObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(c_trainObject);
            obj.SetActive(false);
            pooledTrainObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledTrainObjects.Count; i++)
        {
			// Looking for inactive bullets
            if (!pooledTrainObjects[i].activeInHierarchy)
            {
                return pooledTrainObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(c_trainObject);
            pooledTrainObjects.Add(obj);
            return obj;
        }

        return null;
    }
	
	/*void OnEnable()
	{
	}
	
	//void 
	
	void OnDisable()
	{
	}*/
}
