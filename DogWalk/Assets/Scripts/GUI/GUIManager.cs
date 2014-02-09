using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour
{
	//Button objects
	public GameObject humanA;
	public GameObject humanB;
	public GameObject dogA;
	public GameObject dogB;

	//Player objects
	private GameObject dog;
	private GameObject walker;

	//Events
	//Dog input
	public delegate void dogAHandler( bool isDogAPressed);
	public static event dogAHandler onDogAPressed;

	public delegate void dogBHandler( bool isDogBPressed);
	public static event dogBHandler onDogBPressed;
	
	//Walk Input
	public delegate void walkerAHandler( bool isWalkerAPressed);
	public static event walkerAHandler onWalkerAPressed;
	
	public delegate void walkerBHandler( bool isWalkerBPressed);
	public static event walkerBHandler onWalkerBPressed;

	//Finds the player objects
	void Awake(){
		//Checks to make sure walker is not null before assigning
		if(GameObject.FindGameObjectWithTag(Tags.walker) != null){
			walker = GameObject.FindGameObjectWithTag(Tags.walker);
		}
		//Checks to make sure dog is not null before assigning
		if(GameObject.FindGameObjectWithTag(Tags.dog) != null){
			dog = GameObject.FindGameObjectWithTag(Tags.dog);
		}
	}

	void Update(){
		if (Application.isWebPlayer || Application.isEditor) {
			KeyboardControls();
		}
	}


	//subscribes to the easy touch events when object is enabled
	void OnEnable(){
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	//unsubscribes to the easy touch events when object is disabled
	void OnDisable(){
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}

	void On_ButtonUp (string buttonName) 
	{
		if (buttonName=="button_walker_a"){
			if (onWalkerAPressed != null){
				onWalkerAPressed( true );
			}
		}
		
		if (buttonName=="button_walker_b"){
			if (onWalkerBPressed != null){
				onWalkerBPressed( true );
			}

		}
		
		if (buttonName=="button_dog_a"){
			if (onDogAPressed != null){
				onDogAPressed( true );
			}
		}
		
		if (buttonName=="button_dog_b"){
			if (onDogBPressed != null){
				onDogBPressed( true );
			}
		}

		//Debug.Log(buttonName);
	}


	void KeyboardControls(){
		if(Input.GetKeyUp("z")){
			if (onWalkerAPressed != null){
				onWalkerAPressed( true );
				Debug.Log("working keyboard");

			}
		}
		
		if (Input.GetKeyUp("x")){
			if (onWalkerBPressed != null){
				onWalkerBPressed( true );
				Debug.Log("working keyboard");

			}
			
		}
		
		if (Input.GetKeyUp(",")){
			if (onDogAPressed != null){
				onDogAPressed( true );
				Debug.Log("working keyboard");
			}
		}
		
		if (Input.GetKeyUp(".")){
			if (onDogBPressed != null){
				onDogBPressed( true );
				Debug.Log("working keyboard");

			}
		}
	}
}