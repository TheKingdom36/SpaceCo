using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGen : Interactable {

	

  

    public GameObject PlayerCopy;//used for animations
    public Animator m_animator;
   

    // Use this for initialization


    void Start()
    {
        base.SetUp();

        PowerChangePerSec = 10;
        State = Enums.State.Deactive;
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
        {
            SetActive();
        }

		if(Input.GetKeyDown(KeyCode.T)){
			SetDeactive();
		}

       
    }



    //puts turret in active state triggering animations and swaping character model
    protected override void SetActive(){
        State = Enums.State.Active;
        CallActiveEvent(PowerChangePerSec);
        PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = true;
       
    }

	protected override void SetDeactive(){
		State = Enums.State.Deactive;
        CallDeactiveEvent(PowerChangePerSec);
		PlayerCopy.gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
}
