using UnityEngine;
using System.Collections;

public class Challenger : MonoBehaviour {
	
	//Player objects
	private GameObject dog;
	private GameObject walker;
	private Point point;
	
	private float timer;
	public float challengeTimer;
	public int challengeType;
	
	public float tension;
	
	public int walkerCounter;
	public int dogCounter;
	
	public bool walkerAlternate = false;
	public bool dogAlternate = false;
	
	public int walkerScore;
	public int dogScore;
	
	//subscribes to the input events when object is enabled
	void OnEnable(){
		GUIManager.onWalkerAPressed += onWalkerAPressed;
		GUIManager.onWalkerBPressed += onWalkerBPressed;
		
		GUIManager.onDogAPressed += onDogAPressed;
		GUIManager.onDogBPressed += onDogBPressed;
	}
	//unsubscribes to the input events when object is disabled
	void OnDisable(){
		GUIManager.onWalkerAPressed -= onWalkerAPressed;
		GUIManager.onWalkerBPressed -= onWalkerBPressed;
		
		GUIManager.onDogAPressed -= onDogAPressed;
		GUIManager.onDogBPressed -= onDogBPressed;
	}
	
	
	//Finds the player objects
	void Awake(){
		
		dogCounter = 0;
		walkerCounter = 0;
		
		walkerScore = 0;
		dogScore = 0;

		point = GameObject.FindGameObjectWithTag(Tags.pointController).GetComponent<Point>();
		
		//Checks to make sure walker is not null before assigning
		if(GameObject.FindGameObjectWithTag(Tags.walker) != null){
			walker = GameObject.FindGameObjectWithTag(Tags.walker);
		}
		//Checks to make sure dog is not null before assigning
		if(GameObject.FindGameObjectWithTag(Tags.dog) != null){
			dog = GameObject.FindGameObjectWithTag(Tags.dog);
		}
	}
	
	// Use this for initialization
	void Start () {
		timer += Time.deltaTime;
		resetCounters ();
	}
	
	// Update is called once per frame
	void Update () {
		if (challengeTimer == 0)
						resetCounters ();
		//Debug.Log ("About to choose a challenge");
		//Challenge is determined with object is spawned in the spawner script
		switch (challengeType){
		case 1:
			StartCoroutine(CarChallenge());
			timer = 0;
			break;
		case 2:
			StartCoroutine(SquirrelChallenge());
			break;
		case 3:
			HydrantChallenge();
			timer = 0;
			break;

		}
		tensionCheck ();
		
	}
	
	IEnumerator CarChallenge(){
		
		//Debug.Log("Car challenge starting"); 

		//if timer > 3 goto end condition and exit
		//4 seconds to battle with quick taps. 
		//It is important that the check is only done and processed AFTER the 
		//time has elapsed. This is opposed to making checks every second the event is happening.
		challengeType = 1;
		if(challengeTimer>=4)
		{
			if(dogCounter == walkerCounter ){
				yield break;
			}

			if(Mathf.Max(dogCounter, walkerCounter) == walkerCounter){
				tension -= Mathf.Abs(walkerCounter - dogCounter);
				Debug.Log(tension);
			} else{
				tension += Mathf.Abs(dogCounter - walkerCounter);
				Debug.Log(tension);
			}

			challengeType = 0;
			challengeTimer= 0;
			resetCounters();
			yield break;
		}
		
		challengeTimer += Time.deltaTime;
	}

	IEnumerator SquirrelChallenge(){

		Debug.Log("Squirrel challenge starting"); 
		challengeType = 2;

		if (challengeTimer>= 2) 
		{
			if (dogCounter - walkerCounter >= 1) {
				tension += 10;
				Debug.Log(tension);
				
			}
			if (walkerCounter - dogCounter >= 1) {
				tension -= 10;
			}
			
			challengeType = 0;
			challengeTimer = 0;
			resetCounters ();
			yield break;
		}
		challengeTimer+= Time.deltaTime;
	}

	IEnumerator HydrantChallenge(){

		Debug.Log("Hydrant challenge starting"); 
		challengeType = 3;

		if (challengeTimer >= 8)
		{
			
			if (dogCounter>=walkerCounter)
			{
				tension += 15;
				Debug.Log(tension);
			}
			else
			{
				tension -= 15;
			}
			challengeType = 0;
			challengeTimer = 0;
			resetCounters();
			yield break;
		}
		challengeTimer += Time.deltaTime;
	}
	

	
	void resetCounters()
	{
		dogCounter = 0;
		walkerCounter = 0;
	}
	public void setChallenge(int challengeNumber)
	{
		challengeType = challengeNumber;
	}

	void tensionCheck()
	{
		if (tension >= 30) 
		{
			point.DogPoint();
		}
	}
	
	void onWalkerAPressed(bool isWalkerAPressed){
		if(isWalkerAPressed){
			//Debug.Log("Walker Stop");
				if(walkerAlternate){
					walkerCounter++;
					walkerAlternate = !walkerAlternate;
			}
		}
	}
	
	void onWalkerBPressed(bool isWalkerBPressed){
		if(isWalkerBPressed){
	
				if(!walkerAlternate){
					walkerCounter++;
					walkerAlternate = !walkerAlternate;
			}
		}
	}
	
	void onDogAPressed( bool isDogAPressed )
	{
		if (isDogAPressed)
		{
				if(dogAlternate){
					dogCounter++;
					dogAlternate = !dogAlternate;
			}
		}
		
	}
	
	void onDogBPressed( bool isDogBPressed )
	{
		if (isDogBPressed)
		{

				if(!dogAlternate){
					dogCounter++;
					dogAlternate = !dogAlternate;
			}
		}
		
	}

	public void setChallengeType(int type){
			challengeType = type;
	}
}