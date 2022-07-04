using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public GameObject poolObject;
    [SerializeField] private List<GameObject> _poolList = new List<GameObject>();
    [SerializeField] private int poolAmount;

    private void Start()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            _poolList.Add(Instantiate(poolObject));
            _poolList[i].SetActive(false);
            _poolList[i].transform.parent = transform;
        }
    }
  
    public GameObject SpawnPoolObject(Vector3 position, Quaternion rotation)
    {
        GameObject toReturn;

        if(_poolList.Count > 0)
        {
            toReturn = _poolList[0];
            _poolList.RemoveAt(0);
        }
        else
        {
            toReturn = Instantiate(poolObject);
            toReturn.transform.parent = transform;
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
