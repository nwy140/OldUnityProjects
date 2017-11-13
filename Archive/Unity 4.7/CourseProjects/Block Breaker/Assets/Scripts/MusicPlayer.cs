using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	// Use this for initialization
	
	
	#region Functions
	void Awake () { 
		Debug.Log ("Music player Awake"+ GetInstanceID());
		
		if ( instance!= null) {
			Destroy (gameObject);
			print ("Duplicate music player self destructing");
		}
		else {
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	}
	#endregion
	void Start () {//[Bugs] more than 1 music instances running at once// [SOLUTION] Destroy new music instances if 1 instance is already running
		Debug.Log ("Music player Awake"+ GetInstanceID());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

