
using UnityEngine;

public class Player : TankView
{
    private void OnCollisionEnter(Collision collision)
    {
        SetDamage(1);
    }
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
        Destroy(this.gameObject);
        GameManager.Instance.SpawnPlayer();
    }

}
