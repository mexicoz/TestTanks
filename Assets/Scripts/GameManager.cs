
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPointsPlayer;
    [SerializeField] private GameObject[] _spawnPointsEnemy;

    private void Start()
    {

        Instantiate(_player, ShoosPlayerSpawnPoint(), Quaternion.identity);
        Instantiate(_enemy, ShoosEnemySpawnPoint(), Quaternion.identity);
    }
    Vector3 ShoosPlayerSpawnPoint()
    {
        var element = _spawnPointsPlayer[Random.Range(0, _spawnPointsPlayer.Length)];

        return element.transform.position;
    }
    Vector3 ShoosEnemySpawnPoint()
    {
        var element = _spawnPointsEnemy[Random.Range(0, _spawnPointsEnemy.Length)];

        return element.transform.position;
    }
}