
using System;
using System.IO;
using UnityEngine;
public class DataController : MonoBehaviour
{
    private SaveObj obj = new SaveObj();

    private string jsonPath;

    public event Action<int> setPlayerCount;
    public event Action<int> setEnemyCount;

    public void SetPlayerData(int playerCount)
    {
        obj.playerCount = playerCount;
    }
    public void SetEnemyData(int enemyData)
    {
        obj.enemyCount = enemyData;
    }
    private void Start()
    {
        jsonPath = Path.Combine(Application.dataPath, "Save.json");

        if (File.Exists(jsonPath))
        {
            obj = JsonUtility.FromJson<SaveObj>(File.ReadAllText(jsonPath));
            setPlayerCount?.Invoke(obj.playerCount);
            setEnemyCount?.Invoke(obj.enemyCount);
        }        
    }
    private void OnApplicationQuit()
    {
        File.WriteAllText(jsonPath, JsonUtility.ToJson(obj));
    }    
}

[Serializable]
public class SaveObj
{
    public int playerCount;
    public int enemyCount;
}

