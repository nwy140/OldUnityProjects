using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	
	
	
	int max ;
	int min;
	int guess;
	
	public Text text;
	
	int maxGuessAllowed=10;
	
	// Use this for initialization
	void Start () {
		StartGame ();
		
	}
	//
	void StartGame () {
		max = 10000 ;
		min = 1 ;
		
		guess = 500;
		
		
		max = max + 1;
		
	
	}


	// Update is called once per frame
	/* void Update () {
	
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
		//	print("Up key was pressed");
			GuessHigher();


			
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) { 	
		//	print("Down key was pressed");
			GuessLower();

			
		
		}  else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I won!");
			StartGame ();
        }
	
	}*/
	//
	#region inputclicks
	public void GuessHigher(){
		min = guess;
		NextGuess() ;
	
	}
	public void GuessLower(){
		max = guess;
		NextGuess() ;
		maxGuessAllowed=maxGuessAllowed-1;
		
		text.text= guess.ToString();	
			if (maxGuessAllowed<=0) {
			Application.LoadLevel ("Win"); 
			}
		
	}
	
	
	#endregion
	//
	void NextGuess() {
		guess = (max+min)/2;

	}
	//	


	
	
	
	}

//
