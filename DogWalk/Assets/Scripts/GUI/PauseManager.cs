using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject muteButton;
	public GameObject unMuteButton;
	public GameObject continueButton;
	public GameObject backButton;
	public GameObject restartButton;
	public float savedTimeScale;
	private float startTime = 0.1f;


	public bool pause;
	public GameObject start;


	void OnEnable(){
		pause = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	
	void OnDisable(){
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}
	
	
	
	void On_ButtonUp (string buttonName){

		if (buttonName=="Pause"){
			//Pause the game

			pause = !pause;
			Debug.Log("pause status" + pause);
			if(pause == false) UnPauseGame();
			if(pause == true) PauseGame();
		}


		if (buttonName=="muteButton"){
			muteButton.SetActive(false);
			unMuteButton.SetActive(true);
			ModeManager.Instance.mute(true);
			
			
		}
		
		if (buttonName=="unMuteButton"){
			muteButton.SetActive(true);
			unMuteButton.SetActive(false);
			ModeManager.Instance.mute (false);
		}	
	}

	void PauseGame() {
		ModeManager.Instance.pause(true);
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		//continueButton.SetActive(true);
		//backButton.SetActive(true);
		//restartButton.SetActive(true);
		if(ModeManager.Instance.isMuted() == false){
			//muteButton.SetActive(true);	
		}else{
			//unMuteButton.SetActive(true);	
			
		}
	}
	bool IsBeginning() {
		return (Time.time < startTime);
	}

	void UnPauseGame() {
		ModeManager.Instance.pause(false);
		Time.timeScale = 1;//savedTimeScale;
		if(!ModeManager.Instance.isMuted()){
			AudioListener.pause = false;
		}
		//continueButton.SetActive(false);
		//backButton.SetActive(false);
		//restartButton.SetActive(false);
		//muteButton.SetActive(false);
		//unMuteButton.SetActive(false);

		

		if (IsBeginning() && start != null) {
			start.active = true;
		}
	}
	
	bool IsGamePaused() {
		return (Time.timeScale == 0);
	}
	
	void OnApplicationPause(bool pause) {
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
	
	void isPause(bool isPause){
		Debug.Log("Pause");
		pause = true;
	}
}
