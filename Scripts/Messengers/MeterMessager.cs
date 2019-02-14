using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeterMessager:MonoBehaviour  {

    protected Meter m_Meter;
    public abstract void Increase(float amount);
    public abstract void Decrease(float amount);
}


