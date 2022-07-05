
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankPresenter _presenter;

    [SerializeField] public int speed;
    [SerializeField] public int speedBullet;
    [SerializeField] private GameObject _buletAnchor;
    [SerializeField] public int rotateSpeed;
    [SerializeField] private PoolObject bulletPool;
    [SerializeField] private int _recharge;
    private GameObject _bullet;
    private int _lengthRay = 80;
    public bool isRotation;
    public bool _isShot;
    Vector3 fwd;
    RaycastHit hit;

    private void Awake()
    {
        _presenter = new TankPresenter(this);
        _presenter.Subscribe();       
    }
    private void Update()
    {
        MovingControl(speed);
        if (_isShot)
        {
            BulletMovement();
        }
        
        ShotEvent();
    }
    public virtual void ShotEvent()
    {
        fwd = transform.TransformDirection(Vector3.forward) * _lengthRay;
        Debug.DrawRay(transform.position, fwd, Color.green);

        if (Physics.Raycast(transform.position, fwd, out hit, _lengthRay) && !isRotation && !_isShot)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                _presenter.StartFire();
            }
        }
    }
    public virtual void MovingControl(int speed)
    {
        float xDirect = Input.GetAxis("Horizontal");
        float zDirect = Input.GetAxis("Vertical");

        Moving(speed, xDirect, zDirect);
    }

    public void Moving(int speed, float xDirect, float zDirect )
    {
        Vector3 moveDirect = new Vector3(xDirect, 0.0f, zDirect);
        moveDirect.Normalize();        

        transform.position += moveDirect * speed * Time.deltaTime;
        
        if(moveDirect != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirect, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                targetRotation, rotateSpeed * Time.deltaTime);
            if (targetRotation == transform.rotation)
                isRotation = false;
            else
                isRotation = true;
        }        
    }
    IEnumerator IRocketRecharge()
    {
        yield return new WaitForSeconds(_recharge);
        bulletPool.ReturnPoolObject(_bullet);
        _isShot = false;
    }    
    public void Fire()
    {
        _isShot = true;
        _bullet = bulletPool.SpawnPoolObject(_buletAnchor.transform.position, _buletAnchor.transform.rotation);
        StartCoroutine(IRocketRecharge());
    }
    private void BulletMovement()
    {
        _bullet.transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);
    }
    public void Death()
    {
        //Debug.Log("Death");
    }
    public void SetHp(int damage)
    {
        //Debug.Log(damage);
    }
    public void SetDamage(int damage)
    {
        _presenter.SetDamage(damage);
    }
    
}
