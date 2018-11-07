using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour {

	

    public UnityEngine.UI.Text SpacemanSelectedTextUI;

    //Private Data 
	private SpaceMan ClickedSpaceMan;//Currently user selected SpaceMan
    private bool IsSpaceManClicked = false;
    private Vector3 SpaceManDestination;//Des set by users mouse click
    private Vector3 lastClickedGameObjectCollisionPoint;//point of collsion of last clicked gameobject used for calculateing des position when floor clicked
	private GameObject lastClickedGameObject;//GameObject last clicked by the user
    private RaycastHit PlayerMouseCollisionPointer;//line drawn from user screen click to game world interception point

    // Use this for initialization
    void Start()
    {
        
    }

    void Update () {

        if (Input.GetMouseButtonDown(1)) {
            DeselectSpaceman();
        }


		if (Input.GetMouseButtonDown(0) && IsSpaceManClicked){

			PlayerMouseCollisionPointer = GameObjecthit();
            lastClickedGameObject = PlayerMouseCollisionPointer.collider.gameObject;
            lastClickedGameObjectCollisionPoint = PlayerMouseCollisionPointer.point;

            if (lastClickedGameObject.GetComponent<Interactable>())
            {
                ClickedSpaceMan.MoveTo(lastClickedGameObject.GetComponent<Interactable>());
                DeselectSpaceman();

            } else if (lastClickedGameObject.GetComponent<Floor>()) {
                SpaceManDestination = lastClickedGameObjectCollisionPoint;
                Debug.Log(lastClickedGameObject + " " + SpaceManDestination); 
                ClickedSpaceMan.MoveTo(desination: SpaceManDestination);
                DeselectSpaceman();
            }
            else if (lastClickedGameObject.GetComponent<SpaceMan>()) {
                DeselectSpaceman();//deselect old spaceman

                //Select new SpaceMan
                IsSpaceManClicked = true;
                ClickedSpaceMan = lastClickedGameObject.GetComponent<SpaceMan>();
                ClickedSpaceMan.Selected();
            }
            else
            {

                DeselectSpaceman();
            }

        }else if(Input.GetMouseButtonDown(0)){
            PlayerMouseCollisionPointer = GameObjecthit();
			lastClickedGameObject = PlayerMouseCollisionPointer.collider.gameObject;

            if (lastClickedGameObject.GetComponent<SpaceMan>()) {
                IsSpaceManClicked = true;
                ClickedSpaceMan = lastClickedGameObject.GetComponent<SpaceMan>();
                ClickedSpaceMan.Selected();

            } else if (lastClickedGameObject.GetComponent<Interactable>()) {
                Interactable currentClickedInteractable = lastClickedGameObject.GetComponent<Interactable>();
                if (currentClickedInteractable.State == Enums.State.Active) {
                    ClickedSpaceMan = currentClickedInteractable.PilotSpaceman;
                    IsSpaceManClicked = true;
                }
            }
            else {
                DeselectSpaceman();
            }

		}

        UpdateUI();

		
		
	}

    private void UpdateUI() {
        if (ClickedSpaceMan != null) {
            SpacemanSelectedTextUI.text = ClickedSpaceMan.name;
        }
        else {
            SpacemanSelectedTextUI.text = "None";
        }
    }

	private void DeselectSpaceman()
	{
        ClickedSpaceMan.Deselected();
		IsSpaceManClicked = false;
        ClickedSpaceMan = null;
		SpaceManDestination = Vector3.zero;
	}

	private static RaycastHit hit = new RaycastHit();
    private static Ray ScreenToWorldRay;


   
	public static RaycastHit GameObjecthit(){

        ScreenToWorldRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            
        Physics.Raycast(ScreenToWorldRay, out hit);

		return hit;
    }
				

	

}

				/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
public class UserCursor : MonoBehaviour {
    Vector2 mousePos;
    Vector3 CameraDirection;
    public GameObject game;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        CameraDirection = Camera.main.transform.forward;
    }
    
    // Update is called once per frame
    void Update () {
        this.gameObject.transform.position = Input.mousePosition; 
        Ray ray = new Ray ();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;


        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log (Input.mousePosition);

        //  Instantiate<GameObject> (game, Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,ranFloat)), Quaternion.identity, null);

        }
    }
}*/
