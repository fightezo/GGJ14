
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	
	/// <summary>
	/// Plays a sound at the given point in space by creating an empty game object with an AudioSource
	/// in that place and destroys it after it finished playing.
	/// </summary>
	/// <param name="clip"></param>
	/// <param name="point"></param>
	/// <param name="volume"></param>
	/// <param name="pitch"></param>
	/// <returns></returns>
	public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch)
	{
		//Create an empty game object
		GameObject go = new GameObject("Audio: " + clip.name);
		go.transform.position = point;
		
		//Create the source
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
		Destroy(go, clip.length);
		return source;
	}
}