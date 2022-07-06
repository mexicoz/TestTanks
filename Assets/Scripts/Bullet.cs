
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletData bulletData;
    private bool _isShot;

    private void Update()
    {
        if (_isShot)
        {
            BulletMovement();
        }
    }
    private void BulletMovement()
    {
        transform.Translate(Vector3.forward * bulletData.speedBullet * Time.deltaTime);
    }
    public void Shot(bool shot)
    {
        _isShot = shot;
    }
}
