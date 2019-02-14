using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSide :MonoBehaviour{
   
    private List<Enemy> m_Enemies;
    private Enums.Direction m_direction;
    private float m_damagepersec;

    public delegate void ValueMessage(float damagepersec);
    public event ValueMessage e_Fire;

    
    public void Start()
    {
        m_Enemies = new List<Enemy>();
        Damagepersec = 1;
    }

    public void CallFireEvent() {

        if (m_Enemies.Count>1 && e_Fire!=null)
        {
            e_Fire.Invoke(m_Enemies.Count * m_damagepersec);
        }
        
    }

    public void damageEnemy(float amount) {
        if (m_Enemies.Count > 0)
        {
            m_Enemies[0].decreaeHealth(amount);
            if (m_Enemies[0].GetHealth() <= 0)
            {
                m_Enemies.Remove(m_Enemies[0]);
            }
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

    public Enums.Direction Direction
    {
        get
        {
            return m_direction;
        }

        set
        {
            m_direction = value;
        }
    }

    public int GetEnemyCount() {
        return m_Enemies.Count;
    }

    public Enums.Direction GetDirection() {
        return Direction;
    }

    
}
