using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

    
    public class PowerMeterMessenger : MeterMessager
    {
        void Start() {
            m_Meter = GameObject.FindObjectOfType<Power>();  
        }

        public override void Increase(float amount)
        {
            m_Meter.PositiveChangePerSecond(amount);
        }

        public override void Decrease(float amount)
        {
            m_Meter.NegitiveChangePerSecond(amount);
        }
    }

