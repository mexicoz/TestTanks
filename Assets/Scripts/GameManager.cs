
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _spawnPoints;
    private PlayerPresenter _playerPresenter;
    private PlayerModel _playerModel;

    private void Start()
    {
        _playerModel = new PlayerModel();

        _playerPresenter = new PlayerPresenter(_playerModel, _playerView);

        var playerObject = Instantiate(_playerView, ShoosSpawnPoint(), Quaternion.identity);
    }
    Vector3 ShoosSpawnPoint()
    {
        var element = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        return element.transform.position;
    }
}
