using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterMessager  {
	public Power m_Power;
    public ShipHealth m_ShipHealth;
    public EnemyManager m_EnemyManager;
   
	// Use this for initialization
	public MeterMessager (Power power,ShipHealth shipHealth,EnemyManager enemyManager) {
		m_Power = power;
        m_ShipHealth = shipHealth;
        m_EnemyManager = enemyManager;
	}

	public void PowerIncrease(float amount){
		m_Power.PositiveChangePerSecond(amount);
	}

	public void PowerDecrease(float amount)
    {
		m_Power.NegitiveChangePerSecond(amount);
    }

    public void ShipHealthIncrease(float amount)
    {
        m_ShipHealth.PositiveChangePerSecond(amount);
    }

    public void ShipHealthDecrease(float amount)
    {
        m_ShipHealth.NegitiveChangePerSecond(amount);
    }

    public void jdlddddd(float amount) {
        
    }
}
