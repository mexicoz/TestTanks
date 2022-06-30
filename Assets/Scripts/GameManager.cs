
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject _spawnPointPlayer;

    private void Start()
    {
        Instantiate(_player, _spawnPointPlayer.transform.position, Quaternion.identity);

        foreach (var item in _spawnPoints)
        {
            Instantiate(_enemy, item.transform.position, Quaternion.identity);
        }        
    }
    Vector3 ShoosPlayerSpawnPoint()
    {
        var element = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        return element.transform.position;
    }
    Vector3 ShoosEnemySpawnPoint()
    {
        var element = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        return element.transform.position;
    }
}