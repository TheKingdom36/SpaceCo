using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpaceMan : MonoBehaviour
{
	
//public data   
	public GameObject HighLighter;//gameobject which create a highlight around the Spaceman
    public Interactable CurrentInteractable;//Interactable a SpaceMan is in or going towards
//private data
    private Vector3 m_RecoveryPosition;//vector to save spaceman last position before being deactivated
    private bool FreeControls;//can user select spaceman
    private NavMeshAgent agent;
    private Rigidbody m_rigidbody;

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        FreeControls = true;
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
		HighLighter.SetActive(false);
        CurrentInteractable = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected()
    {
        HighLighter.SetActive(true);
    }

    public void Deselected() {
        HighLighter.SetActive(false);
    }


    public void SetAsActive()
    {
        FreeControls = true;
        gameObject.transform.position = m_RecoveryPosition;
        agent.enabled = true;
        CurrentInteractable.Dismount();
    }

    public void SetAsDeactive(Vector3 RecoveryPosition)
    {
        FreeControls = false;
        m_RecoveryPosition = RecoveryPosition;
        gameObject.transform.position = new Vector3(300, -30, 300);
        agent.isStopped = true;
        agent.enabled = false;

    }

    public void MoveTo(Vector3 desination){

        if (FreeControls==false) {
            SetAsActive();
        }

        CurrentInteractable = null;

        agent.isStopped = false;
        agent.SetDestination(desination);
       
        
	}

    public void MoveTo(Interactable desinationInteractable)
    {
        
        if (FreeControls == false)
        {
            SetAsActive();
        }
        CurrentInteractable = desinationInteractable;

        agent.isStopped = false;
        agent.SetDestination(desinationInteractable.GetInteractionPoint());


    }

    private void OnTriggerEnter(Collider other)
	{
		
	}


}

