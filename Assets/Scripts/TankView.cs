
using UnityEngine;

public class TankView : MonoBehaviour, IMovingControl
{
    TankPresenter _presenter;

    public int speed;
    public int rotateSpeed;

    private void Awake()
    {
        _presenter = new TankPresenter(this);
        _presenter.Subscribe();
    }
    private void Update()
    {
        MovingControl(speed);
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
        }        
    }
    public void Death()
    {
        Debug.Log("Death");
    }

    public void SetHp(int damage)
    {
        Debug.Log(damage);
    }
    public void SetDamage(int damage)
    {
        _presenter.SetDamage(damage);
    }
    void OnMouseDown()
    {
        SetDamage(1);
    }
}
