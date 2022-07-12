
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
    private int _playerCount = -1;
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
    }

    private void Start()
    {
        SpawnPlayer(0);

        foreach (var item in _spawnPointsEnemy)
        {
            Instantiate(_enemy, item.transform.position, Quaternion.identity);
        };
    }
    public void SpawnPlayer(float timeRes)
    {
        _playerCount++;
        _playerCountText.text = _playerCount.ToString();
        StartCoroutine(IRespawnPlayer(timeRes));
    }
    public void SpawnEnemy()
    {
        _enemyCount++;
        _enemyCountText.text = _enemyCount.ToString();
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