
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;
    [SerializeField] private string collisionObject;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(collisionObject))
        {
            collision.gameObject.GetComponent<TankView>().SetDamage(bulletData.atackDamage);
            gameObject.SetActive(false);
        }
    }
}
