using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

//	public Animation animate;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 1; i++){
			animation.PlayQueued("loading");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(animation.isPlaying != true){
			if(Application.GetStreamProgressForLevel(1) == 1){
				Application.LoadLevel(1);
				}
		}
	}
}