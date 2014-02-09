using UnityEngine;
using System.Collections;

public class DogeAnimator : MonoBehaviour {
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void setRun(bool run) {
		anim.SetBool("Running", run);
	}
}
