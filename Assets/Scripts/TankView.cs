
using System.Collections;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankPresenter _presenter;

    [SerializeField] public int speed;
    public int rotateSpeed;
    [SerializeField] public float power;
    [SerializeField] private Rigidbody _bulet;
    [SerializeField] private GameObject _buletAnchor;
    private int _lengthRay = 80;
    private bool _isRotation;
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
        
        RayCast();
    }
    public virtual void RayCast()
    {
        fwd = transform.TransformDirection(Vector3.forward) * _lengthRay;
        if(!_isRotation)
            Debug.DrawRay(transform.position, fwd, Color.green);        
        
        if (Physics.Raycast(transform.position, fwd, out hit, _lengthRay) && !_isRotation)
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
        yield return new WaitForSeconds(2);
        _bulet.isKinematic = true;
        _bulet.transform.position += _buletAnchor.transform.position;
    }
    public void Fire()
    {
        _bulet.GetComponent<MeshRenderer>().enabled = true;
        _bulet.isKinematic = false;
        _bulet.AddForce(transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);
        StartCoroutine(IRocketPool());
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
