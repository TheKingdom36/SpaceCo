using UnityEngine;
using System.Collections;

public class EnemyHealth : Meter
{

    public float GetCurrentValue() {
        return m_RemainingCharge;
    }

    protected override void ChargeEmpty()
    {
        throw new System.NotImplementedException();
    }
}
