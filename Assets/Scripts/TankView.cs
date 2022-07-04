
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankPresenter _presenter;

    [SerializeField] public int speed;
    [SerializeField] public float power;
    [SerializeField] private GameObject _buletAnchor;
    [SerializeField] private int _recharge;
    [SerializeField] public int rotateSpeed;
    [SerializeField] public PoolObject bulletPool;
    private GameObject _bullet;
    private int _lengthRay = 80;
    private bool _isRotation;
    private bool _isShot;
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
        
        RayCast();
    }
    public virtual void RayCast()
    {
        fwd = transform.TransformDirection(Vector3.forward) * _lengthRay;
        if(!_isRotation)
            Debug.DrawRay(transform.position, fwd, Color.green);        
        
        if (Physics.Raycast(transform.position, fwd, out hit, _lengthRay) && !_isRotation && !_isShot)
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
                _isRotation = false;
            else
                _isRotation = true;
        }        
    }
    IEnumerator IRocketPool()
    {
        yield return new WaitForSeconds(_recharge);
        _isShot = false;
        bulletPool.ReturnPoolObject(_bullet);
    }
   
    public void Fire()
    {
        _bullet = bulletPool.SpawnPoolObject(_buletAnchor.transform.position, _buletAnchor.transform.rotation);
        _isShot = true;
        StartCoroutine(IRocketPool());
    }
    private void BulletMovement()
    {
        _bullet.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward)
            * power, ForceMode.Impulse);
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
