using UnityEngine;
using System.Collections;

public class Leash : MonoBehaviour {

	public Color colourDog;
	public Color colourWalker;
	public Color colourNeutral;
	public Color colourLeash;
	public float transitionTime;

	private Challenger challenger;

	void Awake(){
	//	challenger = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Challenger>();
		colourLeash = colourNeutral;
	}

	void Update(){
		colourLeash = Color.Lerp(colourNeutral, colourDog, Time.time * transitionTime);
		renderer.material.color = colourLeash;
	
	}

}

