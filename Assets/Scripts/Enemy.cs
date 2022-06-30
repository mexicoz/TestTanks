
using System.Collections;
using UnityEngine;

public class Enemy : TankView
{
    private float _xDirect;
    private float _zDirect;
    private bool _value;
    private int _lengthRay = 50;
    private void Start()
    {
        StartCoroutine(IDirection());
    }
    private void OnCollisionEnter(Collision other)
    {
        _value = !_value;
        SwitchDirection(_value);
    }   
    private void SwitchDirection(bool value)
    {
        switch (value)
        {
            case true:
                _xDirect = Random.value < 0.5f ? -1 : +1;
                _zDirect = 0;
                break;
            case false:
                _zDirect = Random.value < 0.5f ? -1 : +1;
                _xDirect = 0;
                break;
        }
    }
    IEnumerator IDirection()
    {
        while (true)
        {
            SwitchDirection(Random.value < 0.5f ? true : false);

            yield return new WaitForSeconds(5);
        }       
    }
    public override void RayCast()
    {
        base.RayCast();

        if (Physics.Raycast(transform.position, fwd, out hit, _lengthRay))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                _presenter.StartFire();
            }
        }
    }

    public override void MovingControl(int speed)
    {
        float xDirect = _xDirect;
        float zDirect = _zDirect;

        Moving(speed, xDirect, zDirect);
    }
}
