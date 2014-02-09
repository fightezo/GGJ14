using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void runHandler( bool isRunning);
	public static event runHandler onRunning;
	public delegate void carHandler( bool isCarMoving);
	public static event carHandler isCarMoving;
	public delegate void audioHandler( bool isAudioPlaying);
	public static event carHandler isAudioPlaying;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onGui () {
		/*
		if (GUI.Button (new Rect (5, 5, 150, 40), "Run"))
		{
				if (onRunning != null)
		   			 onRunning( true );
		}
		if (GUI.Button (new Rect (5, 50, 150, 40), "Stop"))
		{
		    	if (onRunning != null)
		    		onRunning( false );
		}
		*/

	}
	void EventCar ()
	{
		GameObject car = GameObject.FindGameObjectWithTag ("car");
		if ( car != null )
		{
			if (isCarMoving != null)
				isCarMoving( true );
			if (isCarMoving != null)
				isCarMoving(true);
		}
	}
}
