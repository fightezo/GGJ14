using UnityEngine;
using System.Collections;

public class FrontKillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.gameObject);
		if (other.gameObject.tag == "distraction")
		{
			Destroy(gameObject);

		}
		
	}
}
