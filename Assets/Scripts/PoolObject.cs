
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> _poolList = new List<GameObject>();
    [SerializeField] private int poolAmount;

    public void Init(GameObject poolObj)
    {
        for (int i = 0; i < poolAmount; i++)
        {
            _poolList.Add(Instantiate(poolObj));
            _poolList[i].SetActive(false);
        }
    }
  
    public GameObject SpawnPoolObject(GameObject poolObj, Vector3 position, Quaternion rotation)
    {
        GameObject toReturn;

        if(_poolList.Count > 0)
        {
            toReturn = _poolList[0];
            _poolList.RemoveAt(0);
        }
        else
        {
            toReturn = Instantiate(poolObj);            
        }

        toReturn.SetActive(true);
        toReturn.transform.position = position;
        toReturn.transform.rotation = rotation;

        return toReturn;
    }
    public void ReturnPoolObject(GameObject objectToReturn)
    {
        _poolList.Add(objectToReturn);
        objectToReturn.SetActive(false);
    }
}
