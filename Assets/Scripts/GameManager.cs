
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spawnPointsPlayer;
    [SerializeField] private GameObject[] _spawnPointsEnemy;

    private void Start()
    {        

        Instantiate(_player, ShoosSpawnPoint(), Quaternion.identity);
    }
    Vector3 ShoosSpawnPoint()
    {
        var element = _spawnPointsPlayer[Random.Range(0, _spawnPointsPlayer.Length)];

        return element.transform.position;
    }
}
