using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public bool useNorth;
    public bool useSouth;
    public bool useEast;
    public bool useWest;

    [SerializeField]public float damagePerEnemy ;
    
    private List<EnemyAttack> m_enemyAttacks = new List<EnemyAttack>();
    private EnemyAttack EastAttack;
    private EnemyAttack WestAttack;
    private EnemyAttack NorthAttack;
    private EnemyAttack SouthAttack;


    private float timeSincelastEnemyCreated;
    private float timelastEnemyCreated;
    public float timeBeforeNextCreation = 2;


    // Use this for initialization
    void Start() {
       
    }


	// Update is called once per frame
     void Update () {
        if (timeBeforeNextCreation < timeSincelastEnemyCreated) {
            CreateNewEnemy();
        }
        timeSincelastEnemyCreated = Time.time - timelastEnemyCreated;

        FireEvents();

    }

    public void Setup() {
        if (useEast == true)
        {
            EastAttack = new EnemyAttack(Enums.Direction.East);
            m_enemyAttacks.Add(EastAttack);
        }

        if (useNorth == true)
        {
            NorthAttack = new EnemyAttack(Enums.Direction.North);
            m_enemyAttacks.Add(NorthAttack);
        }

        if (useSouth == true)
        {
            SouthAttack = new EnemyAttack(Enums.Direction.South);
            m_enemyAttacks.Add(SouthAttack);
        }

        if (useWest == true)
        {
            WestAttack = new EnemyAttack(Enums.Direction.West);
            m_enemyAttacks.Add(WestAttack);
        }
    }

    private void CreateNewEnemy() {
        Enemy enemy = new Enemy();

        int randomNumber = Random.Range(0,m_enemyAttacks.Count);
        m_enemyAttacks[randomNumber].Add(enemy);

        timelastEnemyCreated = Time.time;
    }

    private void FireEvents() {
        foreach (EnemyAttack enemyAtk in m_enemyAttacks) {
            enemyAtk.CallFireEvent();
        }
    }

    public List<EnemyAttack> GetEnemyAttacks() {
        return m_enemyAttacks;
    }

    public void decreaseAttackStrength(Enums.Direction direction,float amount) {
        switch (direction) {
            case Enums.Direction.East:
                //TODO give EnemyAttack a method to inflict damage on the first enemy
                break;
            case Enums.Direction.West:
                break;
            case Enums.Direction.North:
                break;
            case Enums.Direction.South:
                break;
            default:
                break;
        } 
    }
}