using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Power : Meter {
	
    
	
	// Use this for initialization
	void Start () {
        m_MaxCharge = 100;
		m_RemainingCharge = 100;
        m_ChargeChangePerSecond = 0;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
        ApplyChargeChange();
	}

    public Text TextValue;

	private void UpdateUI(){
		TextValue.text = m_RemainingCharge.ToString();

		if(m_RemainingCharge>90){
			TextValue.color = Color.green;
		}else if(m_RemainingCharge>50){
			TextValue.color = Color.yellow;
		}else{
			TextValue.color = Color.red;
		}
	}

    protected override void ChargeEmpty()
    {
        Debug.Log("The power its gone, its all gone");
    }
}
