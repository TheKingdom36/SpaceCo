using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Power : Meter {

    private Assets.UI.PowerUi PowerUi;

    // Use this for initialization
    void Start() {
        m_MaxCharge = 100;
		m_RemainingCharge = 100;
        m_ChargeChangePerSecond = 0;
        PowerUi = gameObject.AddComponent<Assets.UI.PowerUi>();
       
}

    // Update is called once per frame
    void Update () {
        

        if (PowerUi != null)
        {
            PowerUi.UpdateUi(m_RemainingCharge);
        }
        else {
            Debug.Log("Problem");
        }
        
        ApplyChargeChange();

        Debug.Log(m_RemainingCharge);
	}

   

    protected override void ChargeEmpty()
    {
        Debug.Log("The power its gone, its all gone");
    }
}
