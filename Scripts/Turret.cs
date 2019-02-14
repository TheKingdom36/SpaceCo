using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Interactable
{
    public float m_DamagePerSec;
    public GameObject PlayerCopy;//used within Turret animations
    public ValueMessage e_Fire;
    public Enums.Direction direction;

    private Animator m_animator;
    private Vector3 RecoveryPosition;
    
    // Use this for initialization


    void Start()
    {
        base.SetUp();

        PowerChangePerSec = 2;
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = false;
        State = Enums.State.Deactive;
    }

    // Update is called once per frame
    void Update()
    {
		if(State == Enums.State.Active){
            e_Fire.Invoke(m_DamagePerSec);
           
        }
    }
    

    //puts turret in active state triggering animations and swaping character model
	protected override void SetActive(){
        State = Enums.State.Active;
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = true;
        m_animator.SetTrigger("EnterShip");
	}

	protected override void SetDeactive()
    {
        CallDeactiveEvent(PowerChangePerSec);
        State = Enums.State.Deactive;
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}