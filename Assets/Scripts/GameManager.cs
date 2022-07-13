
using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPointsEnemy;
    [SerializeField] private GameObject[] _spawnPointPlayer;
    [SerializeField] private TMP_Text _playerCountText;
    [SerializeField] private TMP_Text _enemyCountText;
    [SerializeField] private DataController dataController;

    private int _playerCount;
    private int _enemyCount;

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
        dataController.setPlayerCount += SetPlayerCount;
        dataController.setEnemyCount += SetEnemyCount;
    }

    private void Start()
    {
        Instantiate(_player, ShoosPlayerSpawnPoint(), Quaternion.identity);

        foreach (var item in _spawnPointsEnemy)
        {
            Instantiate(_enemy, item.transform.position, Quaternion.identity);
        };               
    }
    private void SetPlayerCount(int playerCount)
    {
        _playerCount = playerCount;
        _playerCountText.text = _playerCount.ToString();
    }
    private void SetEnemyCount(int enemyCount)
    {
        _enemyCount = enemyCount;
        _enemyCountText.text = _enemyCount.ToString();
    }
    public void SpawnPlayer(float timeRes)
    {
        _playerCount++;
        _playerCountText.text = _playerCount.ToString();

        dataController.SetPlayerData(_playerCount);

        StartCoroutine(IRespawnPlayer(timeRes));
    }
    public void SpawnEnemy()
    {
        _enemyCount++;
        _enemyCountText.text = _enemyCount.ToString();

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
        var element = _spawnPointPlayer[Random.Range(0, _spawnPointPlayer.Length)];

        return element.transform.position;
    }
    Vector3 ShoosEnemySpawnPoint()
    {
        var element = _spawnPointsEnemy[Random.Range(0, _spawnPointsEnemy.Length)];

        return element.transform.position;
    }
}