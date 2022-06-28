using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : TankView
{
    IMovingControl control;
    private void Start()
    {
        control = GetComponent<IMovingControl>();
    }
    public override void MovingControl(int speed)
    {
        float xDirect = 0;
        float zDirect = 1;
        
        control.Moving(speed, xDirect, zDirect);
    }
}
