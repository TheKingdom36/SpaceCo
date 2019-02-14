using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Enemy : MonoBehaviour  {
    [SerializeField] private EnemyHealth health;


    public float GetHealth() {
        return health.GetCurrentValue();
    }

    public void decreaeHealth(float amount) {
        health.NegitiveChangePerSecond(amount);
    }

  

}
