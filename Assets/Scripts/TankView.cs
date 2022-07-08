
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankPresenter _presenter;

    [SerializeField] private TankData _tankData;
    [SerializeField] private GameObject _buletAnchor;
    [SerializeField] private PoolObject bulletPool;
    public bool isRecharge { get; set; }
    
    private bool isRotation;
    Vector3 fwd;
    RaycastHit hit;

    private void Awake()
    {
        _presenter = new TankPresenter(this);
        _presenter.Subscribe();
        bulletPool.Init(_tankData.bullet);
    }
    private void Update()
    {
        MovingControl(_tankData.speed);        
        ShotEvent();
    }
    public virtual void ShotEvent()
    {
        fwd = transform.TransformDirection(Vector3.forward) * _tankData.rayCastLenght;
        Debug.DrawRay(transform.position, fwd, Color.green);

        if (Physics.Raycast(transform.position, fwd, out hit, _tankData.rayCastLenght) && !isRotation && !isRecharge)
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
                targetRotation, _tankData.rotateSpeed * Time.deltaTime);
            if (targetRotation == transform.rotation)
                isRotation = false;
            else
                isRotation = true;
        }        
    }
    IEnumerator IRocketRecharge(GameObject bullet)
    {
        yield return new WaitForSeconds(_tankData.recharge);
        bulletPool.ReturnPoolObject(bullet);
        isRecharge = false;
    }    
    public void Fire()
    {
        isRecharge = true;
        var bullet = bulletPool.SpawnPoolObject(_tankData.bullet, _buletAnchor.transform.position, _buletAnchor.transform.rotation);
        bullet.GetComponent<Bullet>().Shot(true);
        StartCoroutine(IRocketRecharge(bullet));
    }
    public virtual void Death()
    {
        Debug.Log("You are loose!");
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
