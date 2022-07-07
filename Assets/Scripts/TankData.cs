
using UnityEngine;

[CreateAssetMenu(fileName = "New Tank Data", menuName = "Tank data", order = 50)]
public class TankData : ScriptableObject
{
    [SerializeField] private string _tankName;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private int _recharge;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _rayCastLength;

    public string tankName { get { return _tankName; } }
    public int speed { get { return _speed; } }
    public int rotateSpeed { get { return _rotateSpeed; } }
    public int recharge { get { return _recharge; } }
    public GameObject bullet { get { return _bullet; } set { _bullet = bullet; } }
    public int rayCastLenght { get { return _rayCastLength; } }

}
