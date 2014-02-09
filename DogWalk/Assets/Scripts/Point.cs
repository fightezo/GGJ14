using UnityEngine;
using System;



public class Point : MonoBehaviour {
	public int player_points;
	public int doge_points;

	public int winningPoints;

	public GUIText dogScoreGUI;
	public GUIText walkerSoreGUI;

	private float timer = 0f;
//	public UserSetOption option;

	// Use this for initialization
	void Start () {
		player_points = 0;
		doge_points = 0;
	}
	
		// Update is called once per frame
	void LateUpdate () {
		timer += Time.deltaTime;
		//Debug.Log("timer: " + timer);
		if((int)timer % 15000 == 10){
			timer = 0;
			player_points += 1;
		}
		dogScoreGUI.text = doge_points + "";
		walkerSoreGUI.text = player_points + "";
		CheckWinningCondition();
	}

	public void WalkerPoint(){
		player_points++;
	}

	public void DogPoint(){
		doge_points++;
		timer = 0;
	}

	void CheckWinningCondition(){
		if(player_points == winningPoints){
			Debug.Log("player wins");
			Application.LoadLevel(3);
		}
		
		if(doge_points == winningPoints){
			Debug.Log(winningPoints);
			Debug.Log("dog wins");
			Application.LoadLevel(4);
		}
	}	

}