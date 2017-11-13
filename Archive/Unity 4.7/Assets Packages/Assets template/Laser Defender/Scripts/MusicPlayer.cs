using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	// Use this for initialization
	
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	#region Functions
	void Awake () { 
		Debug.Log ("Music player Awake"+ GetInstanceID());
		
		if ( instance!= null && instance!=this) {
			Destroy (gameObject);
			print ("Duplicate music player self destructing");
			Destroy(gameObject);
		}
		else {
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip=startClip;
			music.loop = true;
			music.Play();
		}
		
	}
	#endregion
	void OnLevelWasLoaded (int level){
		Debug.Log ("MusicPlayer: loaded level " + level);
		music.Stop();
		if(level==0){
			music.clip = startClip;
			music.Play();
		}
		if(level==1||level==2){
			music.clip = gameClip;
			music.Play();
		}
		if(level==3){
			music.clip = endClip;
			music.Play();
		}
		
	}
	
	
	void Start () {//[Bugs] more than 1 music instances running at once// [SOLUTION] Destroy new music instances if 1 instance is already running
		Debug.Log ("Music player Awake"+ GetInstanceID());

	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}

