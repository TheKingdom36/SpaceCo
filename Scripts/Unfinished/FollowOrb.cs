using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOrb : MonoBehaviour
{
    public int value;
    public List<FollowOrb> neighbours = new List<FollowOrb>();
    public Dictionary<FollowOrb, float> NeighbourDistances = new Dictionary<FollowOrb, float>();
    // Use this for initialization
    void Start()
    {

        foreach (FollowOrb neighbour in neighbours)
        {
            NeighbourDistances.Add(neighbour, getDistance(this, neighbour));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private float getDistance(FollowOrb Orb1, FollowOrb Orb2)
    {
        Vector3 Orb1Pos = Orb1.gameObject.transform.position;
        Vector3 Orb2Pos = Orb2.gameObject.transform.position;

        return Mathf.Sqrt(Orb1Pos.x * Orb2Pos.x + Orb1Pos.y * Orb2Pos.y + Orb1Pos.z * Orb2Pos.z);
    }
}
