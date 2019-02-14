using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUi : MonoBehaviour {

    public Text North;
    public Text East;
    public Text West;
    public Text South;


    public void UpdateUi(List<EnemyAttackSide> AtkSideList) {
        foreach (EnemyAttackSide atkside in AtkSideList) {
            switch (atkside.GetDirection())
            {
                case Enums.Direction.East:
                    East.text = atkside.GetEnemyCount().ToString();
                    break;
                case Enums.Direction.West:
                    West.text = atkside.GetEnemyCount().ToString();
                    break;
                case Enums.Direction.North:
                    North.text = atkside.GetEnemyCount().ToString();
                    break;
                case Enums.Direction.South:
                    South.text = atkside.GetEnemyCount().ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
