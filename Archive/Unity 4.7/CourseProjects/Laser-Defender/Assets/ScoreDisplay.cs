using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text currentscore = GetComponent<Text>();
		currentscore.text = Scorekeeper.score.ToString();
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}


