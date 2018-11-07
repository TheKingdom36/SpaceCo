using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Interactable
{
    
    public GameObject PlayerCopy;//used within Turret animations
    public Animator m_animator;
    public Enums.Direction direction;

    // Use this for initialization

  
    void Start()
    {
        base.SetUp();

        PowerChangePerSec = 1;
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = false;
        State = Enums.State.Deactive;
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.W)){
			SetActive();
		}
		if(Input.GetKeyDown(KeyCode.S)){
			SetDeactive();
		}

		
    }

	
    
	private Vector3 RecoveryPosition;

    //puts turret in active state triggering animations and swaping character model
	protected override void SetActive(){
        CallActiveEvent(PowerChangePerSec);
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