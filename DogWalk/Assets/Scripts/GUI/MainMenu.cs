using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	
	public GameObject startButton;
	public GameObject aboutButton;
	public GameObject backButton;	
	

	
	void OnEnable(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		EasyButton.On_ButtonUp += On_ButtonUp;	
	}
	
	void OnDisable(){
		EasyButton.On_ButtonUp -= On_ButtonUp;	
	}

	
	
	void On_ButtonUp (string buttonName){
		
		if (buttonName=="Start"){

			Application.LoadLevel(5);
			
		}
		
		if (buttonName=="About"){

			Application.LoadLevel(2);
			
		}

		if (buttonName=="Back"){
			
			Application.LoadLevel(0);
			
		}
	}
			
}


