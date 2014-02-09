using UnityEngine;
 
/*
the singleton pattern makes it easy to access manager-like object, this example
is component-based. call it using ModeManager.Instance.DoWork(); and the getter
will make sure an instance exists, creating a persistent gameobject if required.
 
only one instance of this implementation may exist at any moment - this is implied
by the singleton concept.
*/
 
public class  ModeManager: MonoBehaviour
{
    private static ModeManager instance;
	private int mode;
	private bool muted = false;
	private bool paused = false;
 
    public static ModeManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("No singleton exists! Creating new one.");
                GameObject owner = new GameObject("ModeManager");
                instance = owner.AddComponent<ModeManager>();
            }
            return instance;
        }
    }
 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
			if(PlayerPrefs.GetInt("Muted") == 1){
				muted = true;	
				AudioListener.pause = true;	
			}else{
				muted = false;
			}
        }
        else if (instance != this)
        {
            Debug.LogWarning("A singleton already exists! Destroying new one.");
            Destroy(this);
        }
 
        //more initialization stuff
    }
 
    public void DoWork()
    {
        Debug.Log("ModeManager is doing the dirty work.");
    }
	
	public void SetMode(int newMode){
		mode = newMode;
	}
	
	public int GetMode(){
		return mode;	
	}
	
	public void mute(bool muteVal){
		muted = muteVal;
		if(muted){
			AudioListener.pause = true;	
			PlayerPrefs.SetInt ("Muted", 1);
		}else{
			AudioListener.pause = false;
			PlayerPrefs.SetInt ("Muted", 0);
		}
		
	}
	
	
	public bool isMuted(){
		return muted;	
	}
	
	public void pause(bool pauseVal){
		paused = pauseVal;	
	}
	
	public bool isPaused(){
		return paused;	
	}
	
	void OnApplicationQuit()
    {
       PlayerPrefs.Save();
    }
}
