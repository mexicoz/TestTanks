
using UnityEngine;

public class Player : TankView
{
    private void OnCollisionEnter(Collision collision)
    {
        SetDamage(1);
    }    
}
