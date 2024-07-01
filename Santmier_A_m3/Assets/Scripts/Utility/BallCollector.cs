using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
    public Boolean hasBall = false;

    public void RecieveBall()
    {
        hasBall = true;
    }

}
