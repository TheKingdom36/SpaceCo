using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class ShipHealthMessenger:MeterMessager
    {
        void Start() {
            m_Meter = this.gameObject.GetComponent<ShipHealth>();
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

