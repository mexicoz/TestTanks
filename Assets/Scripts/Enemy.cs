
using System.Collections;
using UnityEngine;

public class Enemy : TankView
{
    private float _xDirect;
    private float _zDirect;
    private bool _value;
    
    private void Start()
    {
        StartCoroutine(IDirection());
        
    }
    private void OnCollisionEnter(Collision other)
    {
        //_value = !_value;
        Reversal(_value);        
    }   
    
    private void SwitchDirection(bool value)
    {
        switch (value)
        {
            case true:
                _xDirect = Random.value < 0.5f ? -1 : 1;
                _zDirect = 0;
                break;
            case false:
                _zDirect = Random.value < 0.5f ? -1 : 1;
                _xDirect = 0;
                break;
        }
    }
    private void Reversal(bool value)
    {
        switch (value)
        {
            case true:
                _xDirect = _xDirect > 0 ? -1 : 1;
                _zDirect = 0;
                break;
            case false:
                _zDirect = _zDirect > 0 ? -1 : 1;
                _xDirect = 0;
                break;
        }
    }
    IEnumerator IDirection()
    {
        while (true)
        {
            _value = Random.value < 0.5f ? true : false;
            SwitchDirection(_value);

            yield return new WaitForSeconds(5);
        }       
    }
    public override void RayCast()
    {
        base.RayCast();
        
    }

    public override void MovingControl(int speed)
    {
        float xDirect = _xDirect;
        float zDirect = _zDirect;

        Moving(speed, xDirect, zDirect);
    }
}
