using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void setPull(bool pull) {
		anim.SetBool("Pulling", pull);
	}
}
