
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Data", menuName = "Bullet data", order = 50)]
public class BulletData : ScriptableObject
{
    [SerializeField] private string _bulletName;
    [SerializeField] private int _atackDamage;
    [SerializeField] public int _speedBullet;

    public string bulletName { get { return _bulletName; } }
    public int atackDamage{ get { return _atackDamage; } }
    public int speedBullet { get { return _speedBullet; } }
}
