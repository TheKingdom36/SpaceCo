using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipHealth : Meter {
   
    // Use this for initialization
    void Start () {
        m_ChargeChangePerSecond = 0;
        m_MaxCharge = 100;
        m_RemainingCharge = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
        ApplyChargeChange();
        UpdateUI();
        Debug.Log("ShipHealth REmaining charge" + m_RemainingCharge);
       // Debug.Log("ShipHealth charge change per second" + m_ChargeChangePerSecond);
    }

    protected override void ChargeEmpty()
    {
        Debug.Log("The ships shields have failed, were all dead");
    }

    public Text TextValue;

    private void UpdateUI()
    {
        TextValue.text = m_RemainingCharge.ToString();

        if (m_RemainingCharge > 90)
        {
            TextValue.color = Color.green;
        }
        else if (m_RemainingCharge > 50)
        {
            TextValue.color = Color.yellow;
        }
        else
        {
            TextValue.color = Color.red;
        }
    }
}
