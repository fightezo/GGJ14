using UnityEngine;
using System.Collections;
[System.Serializable]
public class Distractions
{

	public GameObject car;
	public GameObject animal;
	public GameObject hydrant;


	
}

public class spawner : MonoBehaviour {
	public Distractions distractions;
	public float spawnWait;
	public float startWait;

	private Challenger challenger;

	

	public Vector3 position = new Vector3(-41f,4f,9f);


	void Awake(){
		challenger = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Challenger>();
	}

	// Update is called once per frame
	void Start () {		
		StartCoroutine(SpawnDistraction());
	}

	IEnumerator SpawnDistraction(){
		
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i = 0; i < 1; i++){
				int rand = Random.Range (1,4);
				challenger.setChallengeType(rand);
				Debug.Log("random spawn " + rand); 
//				Debug.Log(rand%2+1);
				switch(rand) {
				case 1:
						Instantiate (distractions.car, position, Quaternion.identity);
						break;
				case 2:
						Instantiate (distractions.animal, position, Quaternion.identity);
				break;

				case 3:
						Instantiate (distractions.hydrant, position, Quaternion.identity);
						break;
				}	

				// broadcast a challenge
				//Debug.Log("Spawned a distraction");
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}
	
}
