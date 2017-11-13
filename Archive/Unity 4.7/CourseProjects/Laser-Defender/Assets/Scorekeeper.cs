using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {
	public static int score = 0;
	public  static Text currentscore;
	
	
	void Start(){
		
		currentscore = GetComponent<Text>();
		Reset();
	}
	public void Score(int points) {
	Debug.Log ("Scoredpoints");
		score+=points;
		currentscore.text = score.ToString();
	}
	
	public static void Reset(){
		score = 0;
		currentscore.text = score.ToString();
	}	
		
}


