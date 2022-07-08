
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPointsEnemy;
    [SerializeField] private GameObject[] _spawnPointPlayer;

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
        SpawnPlayer();

        foreach (var item in _spawnPointsEnemy)
        {
            Instantiate(_enemy, item.transform.position, Quaternion.identity);
        };
    }
    public void SpawnPlayer()
    {
        Instantiate(_player, ShoosPlayerSpawnPoint(), Quaternion.identity);
    }
    public void SpawnEnemy()
    {
        Instantiate(_enemy, ShoosEnemySpawnPoint(), Quaternion.identity);
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