//using UnityEngine;
//using System.Collections;
//
//public class FrontKillBox : MonoBehaviour {
//
//	// Use this for initialization
//	void Start (){
//	
//	}
//	
//	// Update is called once per frame
//	void Update (){
//	
//	}
//
//	void OnTriggerEnter(Collider other){
//		if (other.gameObject.tag == "distraction")
//		{
//			Destroy(gameObject);
//		}
//		
//	}
//
//}

using UnityEngine;
using System.Collections;

public class FrontKillBox : MonoBehaviour{
	void OnTriggerEnter(Collider other){
		Destroy(other.gameObject);
	}
}