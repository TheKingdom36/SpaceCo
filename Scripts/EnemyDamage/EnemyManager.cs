using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject P_EnemyAttackSide;
    public GameObject P_Enemy;
    public bool useNorth;
    public bool useSouth;
    public bool useEast;
    public bool useWest;
    public EnemyUi m_enemyUi;
    [SerializeField]public float damagePerEnemy ;
    
    public List<EnemyAttackSide> m_enemyAttacksSides = new List<EnemyAttackSide>();
   public EnemyAttackSide EastAttack;
    public EnemyAttackSide WestAttack;
    public EnemyAttackSide NorthAttack;
    public EnemyAttackSide SouthAttack;


    private float timeSincelastEnemyCreated;
    private float timelastEnemyCreated;
    public float timeBeforeNextCreation = 20;


    // Use this for initialization
    void Start() {
        
    }

    private EnemyAttackSide SetUpAttackSide(Enums.Direction direction) {
        EnemyAttackSide AttackSide = Instantiate(P_EnemyAttackSide).GetComponent<EnemyAttackSide>();
        AttackSide.Direction = direction;
        AttackSide.transform.SetParent(this.transform);
        return AttackSide;
    }


	// Update is called once per frame
     void Update () {
        
        if (timeBeforeNextCreation < timeSincelastEnemyCreated) {
            CreateNewEnemy();
        }
        timeSincelastEnemyCreated = Time.time - timelastEnemyCreated;

        FireEvents();
        m_enemyUi.UpdateUi(m_enemyAttacksSides);
       

    }

    public void Setup() {

        if (useEast == true)
        {
            EastAttack = SetUpAttackSide(Enums.Direction.East);

            m_enemyAttacksSides.Add(EastAttack);
        }

        if (useNorth == true)
        {
            NorthAttack = SetUpAttackSide(Enums.Direction.North);
            m_enemyAttacksSides.Add(NorthAttack);
        }

        if (useSouth == true)
        {
            SouthAttack = SetUpAttackSide(Enums.Direction.South);
            m_enemyAttacksSides.Add(SouthAttack);
        }

        if (useWest == true)
        {
            WestAttack = SetUpAttackSide(Enums.Direction.West);
            m_enemyAttacksSides.Add(WestAttack);
        }

    }

    public void SubscribeToAttacksides(MeterMessager mm) {
        if (m_enemyAttacksSides.Count > 0)
        {
            foreach (EnemyAttackSide enemyAtk in m_enemyAttacksSides)
            {
                enemyAtk.e_Fire += mm.Decrease;
            }
        }
    }

    private void CreateNewEnemy() {
       

        int randomNumber = Random.Range(0,m_enemyAttacksSides.Count);
        m_enemyAttacksSides[randomNumber].Add(Instantiate(P_Enemy).GetComponent<Enemy>());

        timelastEnemyCreated = Time.time;
    }

    private void FireEvents() {
        foreach (EnemyAttackSide enemyAtk in m_enemyAttacksSides) {
            enemyAtk.CallFireEvent();
        }
    }

    public List<EnemyAttackSide> GetEnemyAttacks() {
        return m_enemyAttacksSides;
    }

    public void decreaseAttackStrength(Enums.Direction direction,float amount) {
        switch (direction) {
            case Enums.Direction.East:
                //TODO give EnemyAttackSide a method to inflict damage on the first enemy
                if (EastAttack != null) {
                    EastAttack.damageEnemy(amount);
                }
                break;
            case Enums.Direction.West:
                if (WestAttack != null)
                {
                    WestAttack.damageEnemy(amount);
                }
                break;
            case Enums.Direction.North:
                if (NorthAttack != null)
                {
                    NorthAttack.damageEnemy(amount);
                }
                break;
            case Enums.Direction.South:
                if (SouthAttack != null)
                {
                    SouthAttack.damageEnemy(amount);
                }
                break;
            default:
                break;
        } 
    }

}