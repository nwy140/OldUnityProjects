using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	
	
	
	int max ;
	int min;
	int guess;
	
	public Text text;
	
	public int maxGuessAllowed=10;
	
	// Use this for initialization
	void Start () {
		StartGame ();
		
	}
	//
	void StartGame () {
		max = 1000 ;
		min = 1 ;
		
		
		
	 NextGuess();
		
	//	max = max + 1;
		
	
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

		
	}
	
	
	#endregion
	//
	void NextGuess() {
		//guess = (max+min)/2;
		guess = Random.Range(min,max+1);
		maxGuessAllowed=maxGuessAllowed-1;
		
		text.text= guess.ToString();	
		if (maxGuessAllowed<=0) {
			Application.LoadLevel ("Win"); 
		}

	}
	//	


	
	
	
	}

//
