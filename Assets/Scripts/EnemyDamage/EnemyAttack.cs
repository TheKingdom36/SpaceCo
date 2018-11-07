using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack {

    private List<Enemy> m_Enemies;
    private Enums.Direction m_direction;
    private float m_damagepersec;

    public delegate void ValueMessage(float damagepersec);
    public event ValueMessage e_Fire;

    public EnemyAttack(Enums.Direction direction) {
        m_Enemies = new List<Enemy>();
        m_direction = direction;
        Damagepersec = 1; 
    }

    public void CallFireEvent() {

        if (m_Enemies.Count>1 && e_Fire!=null)
        {
            e_Fire(m_Enemies.Count*m_damagepersec);
        }
        
    }

    public void damageEnemy(float amount) {
        m_Enemies[0].decreaeHealth(amount);

        if (m_Enemies[0].GetHealth() < 0) {

        }
    }

    public void Add(Enemy enemy) {
        m_Enemies.Add(enemy);
    }

   
public float Damagepersec
    {
        get
        {
            return m_damagepersec;
        }

        set
        {
            m_damagepersec = value;
        }
    }
}
