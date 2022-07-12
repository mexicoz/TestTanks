
using UnityEngine;

public class Player : TankView
{
    
    public override void ShotEvent()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !isRecharge)
        {
            _presenter.StartFire();
        }
    }
    public override void Death()
    {
        base.Death();
        Debug.Log("You are loose!");
        GameManager.Instance.SpawnPlayer(1);
    }
    public override void MovingControl(int speed)
    {
       float xDirect = Input.GetAxis("Horizontal");
       float zDirect = Input.GetAxis("Vertical");      

       Moving(speed, xDirect, zDirect);
    }    
}
