using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
	InteractionPoint m_interactionPoint;

    public delegate void ValueMessage(float amount);
    public delegate void EmptyMessage();
   
    public event ValueMessage e_Active;
    public event ValueMessage e_Deactive;

    private SpaceMan m_pilotSpaceman;

    [SerializeField] private float m_PowerChangePerSec;

    
    [SerializeField] private Enums.State m_state;

    public Enums.State State
    {
        get
        {
            return m_state;
        }

        set
        {
            m_state = value;
        }
    }

    public SpaceMan PilotSpaceman
    {
        get
        {
            return m_pilotSpaceman;
        }

        set
        {
            m_pilotSpaceman = value;
        }
    }

    public float PowerChangePerSec
    {
        get
        {
            return m_PowerChangePerSec;
        }

        set
        {
            m_PowerChangePerSec = value;
        }
    }

    // Use this for initialization


    protected void SetUp() {
        m_state = Enums.State.Deactive;
        m_interactionPoint = this.gameObject.GetComponentInChildren<InteractionPoint>();

        if (m_interactionPoint == null) {
            Debug.LogWarning("an interactionPoint object is required by the interactable class");
        }

        
    }

    protected abstract void SetActive() ;

    protected void CallActiveEvent(float amount)
    {
        
            e_Active.Invoke(amount: amount);
        
    }


    protected abstract void SetDeactive();
    protected void CallDeactiveEvent(float amount) {
        e_Deactive(amount);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 GetInteractionPoint(){
		return m_interactionPoint.CentrePoint();
	}
    
    

   

    public void SpaceManInteraction(SpaceMan spaceMan) {
        m_pilotSpaceman = spaceMan;
        m_pilotSpaceman.SetAsDeactive(m_interactionPoint.CentrePoint());//will be replaced by interactable animation spaceman
        SetActive();
    }

    public bool IsPilotEmpty() {
        if (PilotSpaceman == null)
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void Dismount() {
        PilotSpaceman = null;
        CallDeactiveEvent(amount: m_PowerChangePerSec);
    }
  
}
