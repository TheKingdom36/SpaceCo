using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour { 

	private MeterMessager m_MeterMessager;

    [SerializeField] private Turret[] level_turrets;
    [SerializeField] private PowerGen[] level_powerGens;
    private EnemyManager m_EnemyManager;

	// Use this for initialization
	void Start () {

        m_EnemyManager = gameObject.GetComponent<EnemyManager>();
		m_MeterMessager = new MeterMessager(gameObject.GetComponent<Power>(),gameObject.GetComponent<ShipHealth>(),m_EnemyManager);
       
        level_turrets = GameObject.FindObjectsOfType<Turret>();

        foreach (Turret turret in level_turrets)
        {
            turret.e_Active += m_MeterMessager.PowerDecrease;
            turret.e_Deactive += m_MeterMessager.PowerIncrease;
         
        }

        level_powerGens = GameObject.FindObjectsOfType<PowerGen>();

        foreach (PowerGen powergen in level_powerGens) {
            powergen.e_Active += m_MeterMessager.PowerIncrease;
            powergen.e_Deactive += m_MeterMessager.PowerDecrease;
        }

        m_EnemyManager.Setup();
        if (m_EnemyManager.GetEnemyAttacks().Count > 0 ) {
            foreach (EnemyAttack enemyAtk in m_EnemyManager.GetEnemyAttacks())
            {
               
                enemyAtk.e_Fire += m_MeterMessager.ShipHealthDecrease;
            }
        }


    }

    public void Update()
    {
     
    }

    public MeterMessager GetMeterMessager(){
		return m_MeterMessager;
	}
}
