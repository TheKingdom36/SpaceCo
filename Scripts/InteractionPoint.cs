using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour {

    Interactable ParentInteractable;
	// Use this for initialization
	void Start () {
        ParentInteractable = gameObject.GetComponentInParent<Interactable>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 CentrePoint(){
        
        return this.gameObject.transform.position;
	}

   
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.GetComponent<SpaceMan>())
        {//if spacemans current interactable is equal to our parent interactable accept spaceman
            if (other.gameObject.GetComponent<SpaceMan>().CurrentInteractable == ParentInteractable
                && ParentInteractable.IsPilotEmpty()) {
             
               ParentInteractable.SpaceManInteraction(other.gameObject.GetComponent<SpaceMan>());
            }
        }
    }


}
