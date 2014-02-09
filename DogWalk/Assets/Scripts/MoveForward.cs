using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += (Vector3.right * Time.deltaTime)*10;
	}

}
