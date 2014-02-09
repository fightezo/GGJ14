using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {
	public Vector3 soundPosition = new Vector3(0f,0f,0f);
	public float movementSpeed = 15;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void onEnable () 
	{
		EventManager.onRunning += onRunning;
		EventManager.isCarMoving += isCarMoving;
	}

	void onDisable () 
	{
		EventManager.onRunning -= onRunning;
		EventManager.isCarMoving -= isCarMoving;

	}

	void onRunning( bool isRunning )
	{
		if (isRunning) {
			StartCoroutine (move ());
		} else {
			StopAllCoroutines();
		}
	}

	void isCarMoving( bool isCarMoving )
	{
		if (isCarMoving) {
			audio.Play();
		}
	}

	public IEnumerator move()
	{
		//Vector3 pos = transform.position;
		transform.position = Vector3.Lerp(transform.position, new Vector3(13f,5f,-3f), movementSpeed * Time.deltaTime);
		//Debug.Log( pos.y);

		yield return null;
	}
	/*
	public AudioSource Play(AudioClip clip, Vector3 point, float volume)
	{
		return Play(clip, point, volume, 1f);
	}
	*/
}
