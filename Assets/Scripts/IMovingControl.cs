using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMovingControl
{
    void Moving(int speed, float xDirect, float zDirect);
}
