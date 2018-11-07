using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  {
    [SerializeField] private EnemyHealth health;


    // Use this for initialization
    public Enemy () {
        
	}

    public float GetHealth() {
        return health.GetCurrentValue();
    }

    public void decreaeHealth(float amount) {
        health.NegitiveChangePerSecond(amount);
    }

  

}
