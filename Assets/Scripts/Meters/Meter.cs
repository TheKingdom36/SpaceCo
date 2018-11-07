using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Meter:MonoBehaviour {
    protected float m_ChargeChangePerSecond;
    protected float m_MaxCharge;
    protected float m_RemainingCharge;

    protected abstract void ChargeEmpty();


    public void PositiveChangePerSecond(float amount) {
        m_RemainingCharge += amount*Time.deltaTime;
    }


    public void NegitiveChangePerSecond(float amount) {
        m_RemainingCharge -= amount*Time.deltaTime;
    }

    


    protected void ApplyChargeChange() {

        m_RemainingCharge += (m_ChargeChangePerSecond * Time.deltaTime);//changes Charge change to every frame

        if (m_RemainingCharge > m_MaxCharge)
        {
            m_RemainingCharge = 100;
        }

        if (m_RemainingCharge < 0)
        {
            m_RemainingCharge = 0;
            ChargeEmpty();
        }

    }

   



}
