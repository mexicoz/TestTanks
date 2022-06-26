
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private TankView[] _enemy;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _spawnPoints;

    private void Start()
    {        

        Instantiate(_player, ShoosSpawnPoint(), Quaternion.identity);
    }
    Vector3 ShoosSpawnPoint()
    {
        var element = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        return element.transform.position;
    }
}
