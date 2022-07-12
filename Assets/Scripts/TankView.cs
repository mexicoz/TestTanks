
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankPresenter _presenter;
    public TankData tankData;

    [SerializeField] private GameObject _buletAnchor;
    [SerializeField] private PoolObject _bulletPool;
    public bool isRecharge { get; set; }
    
    private bool isRotation;
    Vector3 fwd;
    RaycastHit hit;

    private void Awake()
    {
        _presenter = new TankPresenter(this);
        _presenter.Subscribe();
        _bulletPool.Init(tankData.bullet);
    }
    private void Update()
    {
        MovingControl(tankData.speed);        
        ShotEvent();
    }
    public virtual void ShotEvent()
    {
        fwd = transform.TransformDirection(Vector3.forward) * tankData.rayCastLenght;
        Debug.DrawRay(transform.position, fwd, Color.green);

        if (Physics.Raycast(transform.position, fwd, out hit, tankData.rayCastLenght) && !isRotation && !isRecharge)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                _presenter.StartFire();
            }
        }
    }
    public virtual void MovingControl(int speed)
    {

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
                targetRotation, tankData.rotateSpeed * Time.deltaTime);
            if (targetRotation == transform.rotation)
                isRotation = false;
            else
                isRotation = true;
        }        
    }
    IEnumerator IRocketRecharge()
    {
        yield return new WaitForSeconds(tankData.recharge);        
        isRecharge = false;
    } 
    IEnumerator IRocketLive(GameObject bullet)
    {
        yield return new WaitForSeconds(5);
        _bulletPool.ReturnPoolObject(bullet);
    }
    public void Fire()
    {
        isRecharge = true;
        var bullet = _bulletPool.SpawnPoolObject(tankData.bullet, _buletAnchor.transform.position, _buletAnchor.transform.rotation);
        bullet.GetComponent<Bullet>().Shot(true);
        StartCoroutine(IRocketRecharge());
        StartCoroutine(IRocketLive(bullet));
    }
    public virtual void Death()
    {
        Destroy(this.gameObject);        
    }
    public void SetHp(int damage)
    {
        Debug.Log(damage);

    }
    public void SetDamage(int damage)
    {
        _presenter.SetDamage(damage);
    }
    
}
