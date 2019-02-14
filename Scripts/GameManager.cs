using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour { 

	private MeterMessager m_MeterMessager;

    [SerializeField] private Turret[] level_turrets;
    [SerializeField] private PowerGen[] level_powerGens;
    public PowerMeterMessenger m_PowerMessenger;
    public ShipHealthMessenger m_ShipHealthMessenger;
    public EnemyManager m_EnemyManager;
    // Use this for initialization
    void Start () {
        
        
        level_turrets = GameObject.FindObjectsOfType<Turret>();
        m_PowerMessenger = gameObject.GetComponent<PowerMeterMessenger>();
        m_ShipHealthMessenger = gameObject.GetComponent<ShipHealthMessenger>();
        m_EnemyManager.Setup();

        foreach (Turret turret in level_turrets)
        {   
            turret.e_Active += m_PowerMessenger.Decrease;
            

            //turret.e_Active += m_EnemyManager.
            if (turret.direction == Enums.Direction.East) {
                turret.e_Fire += m_EnemyManager.EastAttack.damageEnemy;
               
            }

            if (turret.direction == Enums.Direction.West)
            {
                turret.e_Fire += m_EnemyManager.WestAttack.damageEnemy;
            }

            if (turret.direction == Enums.Direction.North)
            {
                turret.e_Fire += m_EnemyManager.NorthAttack.damageEnemy;
            }

            if (turret.direction == Enums.Direction.South)
            {
                turret.e_Fire += m_EnemyManager.SouthAttack.damageEnemy;

            }

        }

        level_powerGens = GameObject.FindObjectsOfType<PowerGen>();

        foreach (PowerGen powergen in level_powerGens) {
            powergen.e_Active += m_PowerMessenger.Increase;
            
        }

      
        m_EnemyManager.SubscribeToAttacksides(m_ShipHealthMessenger);
    }

    public void Update()
    {
        foreach (Turret turret in level_turrets) {
            if (turret.State == Enums.State.Active) {
                m_PowerMessenger.Decrease(turret.PowerChangePerSec);
            }
        }

        foreach (PowerGen powerGen in level_powerGens) {
            if (powerGen.State == Enums.State.Active) {
                m_PowerMessenger.Increase(powerGen.PowerChangePerSec);
            }
        }

    
    }

    public MeterMessager GetMeterMessager(){
		return m_MeterMessager;
	}
}
