using UnityEngine;
using System.Collections;

public class userSetOption : MonoBehaviour {
	int num = 0;
	string text;
	// Use this for initialization
	void Start () {
	
	}
	// You need to attach this script to a GUIText object.
	public int userSetPoint(){
		int temp;
		string numberstring = input();
		if(int.TryParse(numberstring, out temp)){
			num = int.Parse (text);
		}
		return num;
	}

	// Update is called once per frame
	void Update () {

	}
	string input(){
		foreach (char c in Input.inputString) {
			if (c == "\b"[0]){
				if (guiText.text.Length != 0)
					guiText.text = guiText.text.Substring(0, guiText.text.Length - 1);
			}
			else if (c == "\n"[0] || c == "\r"[0]){
				break;
			}
			else{
				guiText.text += c;
			}
		}
		return text = guiText.text;
	}
}

