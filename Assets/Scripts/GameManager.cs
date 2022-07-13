
using System.Collections;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPointsEnemy;
    [SerializeField] private GameObject[] _spawnPointPlayer;
    [SerializeField] private DataController dataController;

    private int _playerCount;
    private int _enemyCount;

    public event Action<int> SetPlayerCount;
    public event Action<int> SetEnemyCount;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        dataController.setPlayerCount += LoadPlayerCount;
        dataController.setEnemyCount += LoadEnemyCount;
    }

    private void Start()
    {
        Instantiate(_player, ShoosPlayerSpawnPoint(), Quaternion.identity);

        foreach (var item in _spawnPointsEnemy)
        {
            Instantiate(_enemy, item.transform.position, Quaternion.identity);
        };               
    }
    private void LoadPlayerCount(int playerCount)
    {
        _playerCount = playerCount;
        SetPlayerCount?.Invoke(playerCount);
    }
    private void LoadEnemyCount(int enemyCount)
    {
        _enemyCount = enemyCount;
        SetEnemyCount?.Invoke(enemyCount);
    }
    public void SpawnPlayer(float timeRes)
    {
        _playerCount++;
        SetPlayerCount?.Invoke(_playerCount);

        dataController.SetPlayerData(_playerCount);

        StartCoroutine(IRespawnPlayer(timeRes));
    }
    public void SpawnEnemy()
    {
        _enemyCount++;
        SetEnemyCount?.Invoke(_enemyCount);

        dataController.SetEnemyData(_enemyCount);

        StartCoroutine(IRespawnEnemy());
    }
    IEnumerator IRespawnEnemy()
    {
        yield return new WaitForSeconds(1);
        Instantiate(_enemy, ShoosEnemySpawnPoint(), Quaternion.identity);
    }
    IEnumerator IRespawnPlayer(float timeRes)
    {
        yield return new WaitForSeconds(timeRes);
        Instantiate(_player, ShoosPlayerSpawnPoint(), Quaternion.identity);
    }

    Vector3 ShoosPlayerSpawnPoint()
    {
        var element = _spawnPointPlayer[UnityEngine.Random.Range(0, _spawnPointPlayer.Length)];

        return element.transform.position;
    }
    Vector3 ShoosEnemySpawnPoint()
    {
        var element = _spawnPointsEnemy[UnityEngine.Random.Range(0, _spawnPointsEnemy.Length)];

        return element.transform.position;
    }
}