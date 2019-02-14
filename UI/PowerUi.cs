using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;
namespace Assets.UI
{
    class PowerUi: MonoBehaviour
    {
      
        Text PowerText;

        public void Start() {
            PowerText = GameObject.Find("PowerUIValue").GetComponent<Text>();
        }


        public void UpdateUi(float pow) {
            float PowerLevel = pow;
            PowerText.text = pow.ToString();
            Debug.Log(pow.ToString());

            if (PowerLevel > 90)
            {
                PowerText.color = Color.green;
            }
            else if (PowerLevel > 50)
            {
                PowerText.color = Color.yellow;
            }
            else
            {
                PowerText.color = Color.red;
            }
        }


    }
}
