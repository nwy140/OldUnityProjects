using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

//Enum var sets
	private enum States {start_m1, bag, leave, wait_0, wait_1 , apple               ,boat , depart                                  ,Null,  mirror, lock_0, start_m1_mirror, sheets_1, lock_1, freedom } ;
	private States myState;
//Enum var sets END

	public Text text;
//v	
	void Start () {
		myState = States.start_m1;
	 }//Start END
//v
	void Update () {
		print (myState);
		if (myState == States.start_m1) {
			state_start_m1 ();
		} else if (myState == States.bag){state_bag();}
		  else if (myState == States.leave){state_leave();}
		 

		}//Update END
//v		
	
		void state_start_m1 () {	
		text.text = "You have been left stranded and abandoned , you have no idea where you are, you need to look for another way home."+"\nThe only thing you have left is a bag and a briefcase around you, be sure to make use of them\n\n" +	"Press B to grab both the bag , L to leave, ";
		if (Input.GetKeyDown (KeyCode.B)) {myState = States.bag; state_bag ();} //
		if (Input.GetKeyDown (KeyCode.L)) {myState = States.leave; state_leave(); }
		                                   
		                                   

								 
		
		}//state_start_m1 END
//v
		void state_bag () {
		
		text.text =  "Letter and Apple discovered. Letter reads\nCome quick to the boat near the beach, there's a boat there you can use , you need to be fast, S.O.S\n" +
			    "Beware of Sea Monsters. Half of our men were eaten by them last night , we were the only ones who managed to escaped via the emergency boat." +
				"Don't you remeber? " + "Name" + ", we can't stay here forever, we need to go. You my friend still hasn't woken up since the incident, so by the time you read this, you are already awake. Before you come, there's a few food and stuff here, just eat it." +
				"\n\n Press A to eat apple and leave, L to leave ";
		if (Input.GetKeyDown (KeyCode.L)) {myState = States.leave; state_leave(); }
	
					
		 else if (Input.GetKeyDown (KeyCode.A)) {
		
			myState= States.apple;  
			text.text = "You ate the apple and left , you wandered towards the nearest shore in search for food" + ". A friend waves at you calling you to get in the boat" + "\n\n You win!!!"; 
			int hunger = 1;  
			Leavie();
			
			myState= States.apple; 
			}
			
		}	
		//v		
	//v
		void state_leave () {
		
		
		text.text = "You left the area and wandered towards the nearest shore in search for food" + ". A friend waves at you calling you to get in the boat" + "\n\n You win";
		      
			}	
	//v					
		void state_boat () {
		text.text = "A few moments of later on the Sea, a giant Sea Monster emerged out of nowhere and crushed the edge of your boat as it eats your friend, causing you to fall in to the sea as the boat turns upside down\n\n" +
					"Press Q to swim towards the Sea Monster, W to swim up to your boat, E to swim away as far from the sea monster and your boat";
	      
		}
		void state_leave_1 ()  {
		
		
		 
		
		myState = States.boat ;
		if (Input.GetKeyDown (KeyCode.D)) {myState = States.boat; state_boat ();
		}	}	
	

		void Leavie (){ myState = States.boat ;
		if (Input.GetKeyDown (KeyCode.D)) {myState = States.boat; state_boat ();
		
		} }
		
		
	
}//END	

        


























//". Your friend is waiting for you at the beach, leave the area and meet up with your friend." + "\n\n Press L to leave";











