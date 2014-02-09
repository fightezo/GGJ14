using UnityEngine;
using System.Collections;

public class Challenger : MonoBehaviour {
	
	//Player objects
	private GameObject dog;
	private GameObject walker;
	private Point point;
	
	private float timer;

	private float resetTimer;

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
		//Debug.Log ("About to choose a challenge");
		//Challenge is determined with object is spawned in the spawner script
		resetTimer++;
		if(resetTimer % 750 == 0){
			challengeType = 0;
		}

		if(challengeType != 0){
			GameObject.FindGameObjectWithTag(Tags.dog).GetComponent<DogeAnimator>().setRun(true);
			GameObject.FindGameObjectWithTag(Tags.walker).GetComponent<PlayerAnimator>().setPull(true);
			GameObject.FindGameObjectWithTag(Tags.leash).GetComponent<LeashAnimator>().setPull(true);
		}
		else{
			GameObject.Find("doge_idle1").GetComponent<DogeAnimator>().setRun(false);
			GameObject.Find("human_idle1").GetComponent<PlayerAnimator>().setPull(false);
			GameObject.Find("Leash").GetComponent<LeashAnimator>().setPull(false);
		}

		switch (challengeType){
		case 1:
			StartCoroutine(CarChallenge());

			break;
		case 2:
			//Debug.Log("case 2");
			StartCoroutine(AnimalChallenge());
			break;
		case 3:
			StartCoroutine(HydrantChallenge());
			break;
		case 0:

			break;
		}
		
		
	}
	
	IEnumerator CarChallenge(){
		
	//	Debug.Log("Car challenge starting"); 
		timer = 0;
		
		//if timer > 3 goto end condition and exit
		//4 seconds to battle with quick taps. 
		//It is important that the check is only done and processed AFTER the 
		//time has elapsed. This is opposed to making checks every second the event is happening. 
		if(challengeTimer>=2)
		{
			if(dogCounter == walkerCounter ){
				yield break;
			}

			if(Mathf.Max(dogCounter, walkerCounter) == walkerCounter){
				tension -= Mathf.Abs(walkerCounter - dogCounter);
			} else{
				point.DogPoint();
				tension += Mathf.Abs(dogCounter - walkerCounter);
			}

			resetCounters();
			challengeType = 0;
			Debug.Break();
			yield break;
		}
		
		challengeTimer += Time.deltaTime;
	}

	IEnumerator AnimalChallenge(){
		
		//	Debug.Log("Car challenge starting"); 
		timer = 0;
		
		//if timer > 3 goto end condition and exit
		//4 seconds to battle with quick taps. 
		//It is important that the check is only done and processed AFTER the 
		//time has elapsed. This is opposed to making checks every second the event is happening. 
		if(challengeTimer>=2)
		{
			if(dogCounter == walkerCounter ){
				yield break;
			}
			
			if(Mathf.Max(dogCounter, walkerCounter) == walkerCounter){
				tension -= Mathf.Abs(walkerCounter - dogCounter);
			} else{
				point.DogPoint();
				tension += Mathf.Abs(dogCounter - walkerCounter);
			}
			
			resetCounters();
			challengeType = 0;
			yield break;
		}
		
		challengeTimer += Time.deltaTime;
	}


	IEnumerator HydrantChallenge(){
		
		//	Debug.Log("Car challenge starting"); 
		timer = 0;
		
		//if timer > 3 goto end condition and exit
		//4 seconds to battle with quick taps. 
		//It is important that the check is only done and processed AFTER the 
		//time has elapsed. This is opposed to making checks every second the event is happening. 
		if(challengeTimer>=2)
		{
			if(dogCounter == walkerCounter ){
				yield break;
			}
			
			if(Mathf.Max(dogCounter, walkerCounter) == walkerCounter){
				tension -= Mathf.Abs(walkerCounter - dogCounter);
			} else{
				point.DogPoint();
				tension += Mathf.Abs(dogCounter - walkerCounter);
			}
			
			resetCounters();
			challengeType = 0;
			yield break;
		}
		
		challengeTimer += Time.deltaTime;
	}

	void resetCounters()
	{
		challengeTimer = 0;
		dogCounter = 0;
	}
	public void setChallenge(int challengeNumber)
	{
		challengeType = challengeNumber;
	}
	
	void onWalkerAPressed(bool isWalkerAPressed){
		if(isWalkerAPressed){
			//Debug.Log("Walker Stop");
			switch (challengeType){
			case 1:
				if(walkerAlternate){
					dogCounter--;
					walkerAlternate = !walkerAlternate;
				}
				break;
			}
		}
	}
	
	void onWalkerBPressed(bool isWalkerBPressed){
		if(isWalkerBPressed){
			//Debug.Log("Walker Treat");
			switch (challengeType){
			case 1:
				if(!walkerAlternate){
					dogCounter--;
					walkerAlternate = !walkerAlternate;
				}
				break;
			}
		}
	}
	
	void onDogAPressed( bool isDogAPressed )
	{
		if (isDogAPressed)
		{
			//Debug.Log("Dog Run");
			switch (challengeType){
			case 1:
				if(dogAlternate){
					dogCounter++;
					dogAlternate = !dogAlternate;
				}
				break;
			}
		}
		
	}
	
	void onDogBPressed( bool isDogBPressed )
	{
		if (isDogBPressed)
		{
			switch (challengeType){
			case 1:
				if(!dogAlternate){
					dogCounter++;
					dogAlternate = !dogAlternate;
				}
				break;
			}
		}
		
	}

	public void setChallengeType(int type){
			challengeType = type;
	}
}